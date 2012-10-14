using System;

namespace CRYFORCE.Engine
{
    /// <summary>
    /// �������� ����������� ������� "��������� ��������� ��������"
    /// </summary>
    public class ProgressChangedArg : MessageReceivedArg
    {
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
            : base(processDescription, messagePostfix, messageClassId)
        {
            ProcessProgress = processProgress;
        }
    }
}