using System;

namespace CRYFORCE.Engine
{
	public struct ProgressChangedArg
	{
		/// <summary>
		/// ����������� ��������� ����������� ������� "��������� ��������� ��������"
		/// </summary>
		/// <param name="processDescription">�������� ��������.</param>
		/// <param name="processProgress">�������� ��������.</param>
		/// <param name="messageClassId">����� ���������.</param>
		public ProgressChangedArg(string processDescription, double processProgress, long messageClassId = 0)
		{			
			ProcessDescription = processDescription;
			ProcessProgress = processProgress;
			MessageClassId = messageClassId;
			MessageGuid = Guid.NewGuid();
		}

		/// <summary>�������� ��������.</summary>
		public readonly string ProcessDescription;

		/// <summary>�������� ��������.</summary>
		public readonly double ProcessProgress;
		
		/// <summary>����� ���������.</summary>
		public readonly long MessageClassId;

		/// <summary>������������� ���������.</summary>
		public readonly Guid MessageGuid;
	}
}