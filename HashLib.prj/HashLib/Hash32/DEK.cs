﻿using System;
using System.Diagnostics;

namespace HashLib.Hash32
{
	class DEK : MultipleTransformNonBlock, IHash32, INonBlockHash
	{
		public DEK()
			: base(4, 1)
		{
		}

		public override HashResult ComputeBytes(byte[] a_data)
		{
			Debug.Assert(a_data != null);

			var hash = (uint)a_data.Length;

			foreach(byte b in a_data)
				hash = ((hash << 5) ^ (hash >> 27)) ^ b;

			return new HashResult(hash);
		}
	}
}