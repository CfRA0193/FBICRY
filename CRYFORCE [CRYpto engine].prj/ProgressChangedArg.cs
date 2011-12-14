using System;

namespace CRYFORCE.Engine
{
	/// <summary>
	/// �������� ����������� ������� "��������� ��������� ��������"
	/// </summary>
	public struct ProgressChangedArg
	{
		/// <summary>����� ���������.</summary>
		public readonly long MessageClassId;

		/// <summary>������������� ���������.</summary>
		public readonly Guid MessageGuid;

		/// <summary>�������� ���������.</summary>
		public readonly string MessagePostfix;

		/// <summary>�������� ��������.</summary>
		public readonly string ProcessDescription;

		/// <summary>�������� ��������.</summary>
		public readonly double ProcessProgress;

		/// <summary>
		/// ����������� ��������� ����������� ������� "��������� ��������� ��������"
		/// </summary>
		/// <param name="processDescription">�������� ��������.</param>
		/// <param name="processProgress">�������� ��������.</param>
		/// <param name="messagePostfix">����-��������� (��������, ������� �������).</param>
		/// <param name="messageClassId">����� ���������.</param>
		public ProgressChangedArg(string processDescription, double processProgress, string messagePostfix = "", long messageClassId = 0)
		{
			ProcessDescription = processDescription;
			ProcessProgress = processProgress;
			MessagePostfix = messagePostfix;
			MessageClassId = messageClassId;
			MessageGuid = Guid.NewGuid();
		}
	}
}