#region

using System;

#endregion

namespace CRYFORCE.Engine
{
    /// <summary>
    /// �������� ����������� ������� "�������� ���������"
    /// </summary>
    public class MessageReceivedArg
    {
        /// <summary>
        /// ���� ���������.
        /// </summary>
        public readonly string MessageBody;

        /// <summary>
        /// ����� ���������.
        /// </summary>
        public readonly long MessageClassId;

        /// <summary>
        /// ������������� ���������.
        /// </summary>
        public readonly Guid MessageGuid;

        /// <summary>
        /// �������� ���������.
        /// </summary>
        public readonly string MessagePostfix;

        /// <summary>
        /// ����������� ��������� ����������� ������� "�������� ���������"
        /// </summary>
        /// <param name="messageBody"> ���� ���������. </param>
        /// <param name="messagePostfix"> �������� ��������� (��������, ������� �������). </param>
        /// <param name="messageClassId"> ����� ���������. </param>
        public MessageReceivedArg(string messageBody, string messagePostfix = "", long messageClassId = 0)
        {
            MessageBody = messageBody;
            MessagePostfix = messagePostfix;
            MessageClassId = messageClassId;
            MessageGuid = Guid.NewGuid();
        }
    }
}