using System;

namespace CRYFORCE.Engine
{
	public struct ProgressChangedArg
	{
		/// <summary>
		/// ����������� ��������� ����������� ������� "��������� ��������� ��������"
		/// </summary>
		/// <param name="processProgress">�������� ��������.</param>
		/// <param name="processDescription">�������� ��������.</param>
		/// <param name="messageClassId">����� ���������.</param>
		public ProgressChangedArg(double processProgress, string processDescription, long messageClassId = 0)
		{
			ProcessProgress = processProgress;
			ProcessDescription = processDescription;
			MessageClassId = messageClassId;
			MessageGuid = Guid.NewGuid();
		}

		/// <summary>�������� ��������.</summary>
		public readonly double ProcessProgress;

		/// <summary>�������� ��������.</summary>
		public readonly string ProcessDescription;

		/// <summary>����� ���������.</summary>
		public readonly long MessageClassId;

		/// <summary>������������� ���������.</summary>
		public readonly Guid MessageGuid;
	}
}