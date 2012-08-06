using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RSACryptoPad
{
	public class EncryptionThread
	{
		private ContainerControl containerControl;
		private Delegate finishedProcessDelegate;
		private Delegate updateTextDelegate;

		public void Encrypt(object inputObject)
		{
			var inputObjects = (object[])inputObject;
			containerControl = (Form)inputObjects[0];
			finishedProcessDelegate = (Delegate)inputObjects[1];
			updateTextDelegate = (Delegate)inputObjects[2];
			string encryptedString = EncryptString((string)inputObjects[3], (int)inputObjects[4], (string)inputObjects[5]);
			containerControl.Invoke(updateTextDelegate, new object[] {encryptedString});
			containerControl.Invoke(finishedProcessDelegate);
		}

		public void Decrypt(object inputObject)
		{
			var inputObjects = (object[])inputObject;
			containerControl = (Form)inputObjects[0];
			finishedProcessDelegate = (Delegate)inputObjects[1];
			updateTextDelegate = (Delegate)inputObjects[2];
			string decryptedString = DecryptString((string)inputObjects[3], (int)inputObjects[4], (string)inputObjects[5]);
			containerControl.Invoke(updateTextDelegate, new object[] {decryptedString});
			containerControl.Invoke(finishedProcessDelegate);
		}

		/// <summary>
		/// ������ ������, ����������� �� ������� ������
		/// </summary>
		/// FBICRY
		/// <param name="stream">����� � ������� ��� ������</param>
		/// <returns>����� �� ������� �������</returns>
		public Stream Compress(Stream stream)
		{
			byte[] compressed;
			stream.Position = 0;
			using(var outStream = new MemoryStream())
			{
				using(var tinyStream = new GZipStream(outStream, CompressionMode.Compress, true))
				{
					stream.CopyTo(tinyStream);
					tinyStream.Flush();
				}
				outStream.Position = 0;
				compressed = outStream.ToArray();
			}
			return new MemoryStream(compressed);
		}

		/// <summary>
		/// ��������� ������ �� ������� ���������
		/// </summary>
		/// FBICRY
		/// <param name="stream">����� �� ������� �������</param>
		/// <returns>����� � ��������� �������</returns>
		public Stream Uncompress(Stream stream)
		{
			byte[] output;
			stream.Position = 0;
			using(var bigStream = new GZipStream(stream, CompressionMode.Decompress, true))
			using(var bigStreamOut = new MemoryStream())
			{
				bigStream.CopyTo(bigStreamOut);
				bigStreamOut.Position = 0;
				output = bigStreamOut.ToArray();
			}
			return new MemoryStream(output);
		}

		/// <summary>
		/// ������������ ������ �� ��������� �������
		/// </summary>
		/// <param name="input">������� �����</param>
		/// <param name="align">������������</param>
		/// <returns>����������� �����</returns>
		public Stream Align(Stream input, int align)
		{
			var output = new MemoryStream();
			input.Seek(0, SeekOrigin.Begin);
			input.CopyTo(output);
			var tail = (byte)(align - output.Length % align);
			output.SetLength(output.Length + tail - 1);
			output.Seek(0, SeekOrigin.End);
			output.WriteByte(tail);
			output.Flush();
			return output;
		}

		/// <summary>
		/// ���������� ������������ ������
		/// </summary>
		/// <param name="input">������� �����</param>
		/// <returns>����������� �����</returns>
		public Stream DeAlign(Stream input)
		{
			input.Position = input.Length - 1;
			int tail = input.ReadByte();
			input.SetLength(input.Length - tail);
			var output = new MemoryStream();
			input.Seek(0, SeekOrigin.Begin);
			input.CopyTo(output);
			output.Flush();
			return output;
		}

		public string EncryptString(string inputString, int dwKeySize, string xmlString)
		{
			var rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
			rsaCryptoServiceProvider.FromXmlString(xmlString);
			int keySize = dwKeySize / 8;
			byte[] bytesInput = Encoding.UTF8.GetBytes(inputString);

			// ������ GZip...
			var input = new MemoryStream(bytesInput);
			var output = (MemoryStream)Compress(input);
			output.Seek(0, SeekOrigin.Begin);
			byte[] bytes = output.ToArray();
			input.Close();
			output.Close();

			//...� ������������ �� ������� 4 �����
			var ms = new MemoryStream(bytes);
			var output2 = (MemoryStream)Align(ms, 4);
			output2.Seek(0, SeekOrigin.Begin);
			byte[] alignedBytes = output2.ToArray();
			ms.Close();
			output2.Close();

			// The hash function in use by the .NET RSACryptoServiceProvider here is SHA1
			// int maxLength = ( keySize ) - 2 - ( 2 * SHA1.Create().ComputeHash( rawBytes ).Length );
			int maxLength = keySize - 42;
			int dataLength = alignedBytes.Length;
			int iterations = dataLength / maxLength;
			var stringBuilder = new StringBuilder();
			for(int i = 0; i <= iterations; i++)
			{
				var tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
				Buffer.BlockCopy(alignedBytes, maxLength * i, tempBytes, 0, tempBytes.Length);
				byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
				stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
			}
			return stringBuilder.ToString();
		}

		public string DecryptString(string inputString, int dwKeySize, string xmlString)
		{
			var rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
			rsaCryptoServiceProvider.FromXmlString(xmlString);
			int base64BlockSize = ((dwKeySize / 8) % 3 != 0) ? (((dwKeySize / 8) / 3) * 4) + 4 : ((dwKeySize / 8) / 3) * 4;
			int iterations = inputString.Length / base64BlockSize;
			var arrayList = new ArrayList();
			for(int i = 0; i < iterations; i++)
			{
				byte[] encryptedBytes = Convert.FromBase64String(inputString.Substring(base64BlockSize * i, base64BlockSize));
				arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedBytes, true));
			}

			var bytesInput = arrayList.ToArray(Type.GetType("System.Byte")) as byte[];

			var ms = new MemoryStream(bytesInput);
			var output2 = (MemoryStream)DeAlign(ms);
			output2.Seek(0, SeekOrigin.Begin);
			byte[] bytesInput2 = output2.ToArray();
			ms.Close();
			output2.Close();

			// ������������ GZip � ������ ������������ ������ �� ������� ����
			var input = new MemoryStream(bytesInput2);
			var output = (MemoryStream)Uncompress(input);
			output.Seek(0, SeekOrigin.Begin);
			byte[] bytes = output.ToArray();
			input.Close();
			output.Close();
			return Encoding.UTF8.GetString(bytes);
		}
	}
}