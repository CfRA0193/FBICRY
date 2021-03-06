using System;

namespace HashLib.Crypto
{
	class RIPEMD320 : MDBase
	{
		public RIPEMD320() : base(10, 40)
		{
		}

		public override void Initialize()
		{
			m_state[0] = 0x67452301;
			m_state[1] = 0xefcdab89;
			m_state[2] = 0x98badcfe;
			m_state[3] = 0x10325476;
			m_state[4] = 0xc3d2e1f0;
			m_state[5] = 0x76543210;
			m_state[6] = 0xFEDCBA98;
			m_state[7] = 0x89ABCDEF;
			m_state[8] = 0x01234567;
			m_state[9] = 0x3C2D1E0F;

			base.Initialize();
		}

		protected override void TransformBlock(byte[] a_data, int a_index)
		{
			var data = new uint[16];
			Converters.ConvertBytesToUInts(a_data, a_index, BlockSize, data);

			uint a = m_state[0];
			uint b = m_state[1];
			uint c = m_state[2];
			uint d = m_state[3];
			uint e = m_state[4];
			uint aa = m_state[5];
			uint bb = m_state[6];
			uint cc = m_state[7];
			uint dd = m_state[8];
			uint ee = m_state[9];

			a += data[0] + (b ^ c ^ d);
			a = ((a << 11) | (a >> (32 - 11))) + e;
			c = (c << 10) | (c >> (32 - 10));
			e += data[1] + (a ^ b ^ c);
			e = ((e << 14) | (e >> (32 - 14))) + d;
			b = (b << 10) | (b >> (32 - 10));
			d += data[2] + (e ^ a ^ b);
			d = ((d << 15) | (d >> (32 - 15))) + c;
			a = (a << 10) | (a >> (32 - 10));
			c += data[3] + (d ^ e ^ a);
			c = ((c << 12) | (c >> (32 - 12))) + b;
			e = (e << 10) | (e >> (32 - 10));
			b += data[4] + (c ^ d ^ e);
			b = ((b << 5) | (b >> (32 - 5))) + a;
			d = (d << 10) | (d >> (32 - 10));
			a += data[5] + (b ^ c ^ d);
			a = ((a << 8) | (a >> (32 - 8))) + e;
			c = (c << 10) | (c >> (32 - 10));
			e += data[6] + (a ^ b ^ c);
			e = ((e << 7) | (e >> (32 - 7))) + d;
			b = (b << 10) | (b >> (32 - 10));
			d += data[7] + (e ^ a ^ b);
			d = ((d << 9) | (d >> (32 - 9))) + c;
			a = (a << 10) | (a >> (32 - 10));
			c += data[8] + (d ^ e ^ a);
			c = ((c << 11) | (c >> (32 - 11))) + b;
			e = (e << 10) | (e >> (32 - 10));
			b += data[9] + (c ^ d ^ e);
			b = ((b << 13) | (b >> (32 - 13))) + a;
			d = (d << 10) | (d >> (32 - 10));
			a += data[10] + (b ^ c ^ d);
			a = ((a << 14) | (a >> (32 - 14))) + e;
			c = (c << 10) | (c >> (32 - 10));
			e += data[11] + (a ^ b ^ c);
			e = ((e << 15) | (e >> (32 - 15))) + d;
			b = (b << 10) | (b >> (32 - 10));
			d += data[12] + (e ^ a ^ b);
			d = ((d << 6) | (d >> (32 - 6))) + c;
			a = (a << 10) | (a >> (32 - 10));
			c += data[13] + (d ^ e ^ a);
			c = ((c << 7) | (c >> (32 - 7))) + b;
			e = (e << 10) | (e >> (32 - 10));
			b += data[14] + (c ^ d ^ e);
			b = ((b << 9) | (b >> (32 - 9))) + a;
			d = (d << 10) | (d >> (32 - 10));
			a += data[15] + (b ^ c ^ d);
			a = ((a << 8) | (a >> (32 - 8))) + e;
			c = (c << 10) | (c >> (32 - 10));

			aa += data[5] + C1 + (bb ^ (cc | ~dd));
			aa = ((aa << 8) | (aa >> (32 - 8))) + ee;
			cc = (cc << 10) | (cc >> (32 - 10));
			ee += data[14] + C1 + (aa ^ (bb | ~cc));
			ee = ((ee << 9) | (ee >> (32 - 9))) + dd;
			bb = (bb << 10) | (bb >> (32 - 10));
			dd += data[7] + C1 + (ee ^ (aa | ~bb));
			dd = ((dd << 9) | (dd >> (32 - 9))) + cc;
			aa = (aa << 10) | (aa >> (32 - 10));
			cc += data[0] + C1 + (dd ^ (ee | ~aa));
			cc = ((cc << 11) | (cc >> (32 - 11))) + bb;
			ee = (ee << 10) | (ee >> (32 - 10));
			bb += data[9] + C1 + (cc ^ (dd | ~ee));
			bb = ((bb << 13) | (bb >> (32 - 13))) + aa;
			dd = (dd << 10) | (dd >> (32 - 10));
			aa += data[2] + C1 + (bb ^ (cc | ~dd));
			aa = ((aa << 15) | (aa >> (32 - 15))) + ee;
			cc = (cc << 10) | (cc >> (32 - 10));
			ee += data[11] + C1 + (aa ^ (bb | ~cc));
			ee = ((ee << 15) | (ee >> (32 - 15))) + dd;
			bb = (bb << 10) | (bb >> (32 - 10));
			dd += data[4] + C1 + (ee ^ (aa | ~bb));
			dd = ((dd << 5) | (dd >> (32 - 5))) + cc;
			aa = (aa << 10) | (aa >> (32 - 10));
			cc += data[13] + C1 + (dd ^ (ee | ~aa));
			cc = ((cc << 7) | (cc >> (32 - 7))) + bb;
			ee = (ee << 10) | (ee >> (32 - 10));
			bb += data[6] + C1 + (cc ^ (dd | ~ee));
			bb = ((bb << 7) | (bb >> (32 - 7))) + aa;
			dd = (dd << 10) | (dd >> (32 - 10));
			aa += data[15] + C1 + (bb ^ (cc | ~dd));
			aa = ((aa << 8) | (aa >> (32 - 8))) + ee;
			cc = (cc << 10) | (cc >> (32 - 10));
			ee += data[8] + C1 + (aa ^ (bb | ~cc));
			ee = ((ee << 11) | (ee >> (32 - 11))) + dd;
			bb = (bb << 10) | (bb >> (32 - 10));
			dd += data[1] + C1 + (ee ^ (aa | ~bb));
			dd = ((dd << 14) | (dd >> (32 - 14))) + cc;
			aa = (aa << 10) | (aa >> (32 - 10));
			cc += data[10] + C1 + (dd ^ (ee | ~aa));
			cc = ((cc << 14) | (cc >> (32 - 14))) + bb;
			ee = (ee << 10) | (ee >> (32 - 10));
			bb += data[3] + C1 + (cc ^ (dd | ~ee));
			bb = ((bb << 12) | (bb >> (32 - 12))) + aa;
			dd = (dd << 10) | (dd >> (32 - 10));
			aa += data[12] + C1 + (bb ^ (cc | ~dd));
			aa = ((aa << 6) | (aa >> (32 - 6))) + ee;
			cc = (cc << 10) | (cc >> (32 - 10));

			e += data[7] + C2 + ((aa & b) | (~aa & c));
			e = ((e << 7) | (e >> (32 - 7))) + d;
			b = (b << 10) | (b >> (32 - 10));
			d += data[4] + C2 + ((e & aa) | (~e & b));
			d = ((d << 6) | (d >> (32 - 6))) + c;
			aa = (aa << 10) | (aa >> (32 - 10));
			c += data[13] + C2 + ((d & e) | (~d & aa));
			c = ((c << 8) | (c >> (32 - 8))) + b;
			e = (e << 10) | (e >> (32 - 10));
			b += data[1] + C2 + ((c & d) | (~c & e));
			b = ((b << 13) | (b >> (32 - 13))) + aa;
			d = (d << 10) | (d >> (32 - 10));
			aa += data[10] + C2 + ((b & c) | (~b & d));
			aa = ((aa << 11) | (aa >> (32 - 11))) + e;
			c = (c << 10) | (c >> (32 - 10));
			e += data[6] + C2 + ((aa & b) | (~aa & c));
			e = ((e << 9) | (e >> (32 - 9))) + d;
			b = (b << 10) | (b >> (32 - 10));
			d += data[15] + C2 + ((e & aa) | (~e & b));
			d = ((d << 7) | (d >> (32 - 7))) + c;
			aa = (aa << 10) | (aa >> (32 - 10));
			c += data[3] + C2 + ((d & e) | (~d & aa));
			c = ((c << 15) | (c >> (32 - 15))) + b;
			e = (e << 10) | (e >> (32 - 10));
			b += data[12] + C2 + ((c & d) | (~c & e));
			b = ((b << 7) | (b >> (32 - 7))) + aa;
			d = (d << 10) | (d >> (32 - 10));
			aa += data[0] + C2 + ((b & c) | (~b & d));
			aa = ((aa << 12) | (aa >> (32 - 12))) + e;
			c = (c << 10) | (c >> (32 - 10));
			e += data[9] + C2 + ((aa & b) | (~aa & c));
			e = ((e << 15) | (e >> (32 - 15))) + d;
			b = (b << 10) | (b >> (32 - 10));
			d += data[5] + C2 + ((e & aa) | (~e & b));
			d = ((d << 9) | (d >> (32 - 9))) + c;
			aa = (aa << 10) | (aa >> (32 - 10));
			c += data[2] + C2 + ((d & e) | (~d & aa));
			c = ((c << 11) | (c >> (32 - 11))) + b;
			e = (e << 10) | (e >> (32 - 10));
			b += data[14] + C2 + ((c & d) | (~c & e));
			b = ((b << 7) | (b >> (32 - 7))) + aa;
			d = (d << 10) | (d >> (32 - 10));
			aa += data[11] + C2 + ((b & c) | (~b & d));
			aa = ((aa << 13) | (aa >> (32 - 13))) + e;
			c = (c << 10) | (c >> (32 - 10));
			e += data[8] + C2 + ((aa & b) | (~aa & c));
			e = ((e << 12) | (e >> (32 - 12))) + d;
			b = (b << 10) | (b >> (32 - 10));

			ee += data[6] + C3 + ((a & cc) | (bb & ~cc));
			ee = ((ee << 9) | (ee >> (32 - 9))) + dd;
			bb = (bb << 10) | (bb >> (32 - 10));
			dd += data[11] + C3 + ((ee & bb) | (a & ~bb));
			dd = ((dd << 13) | (dd >> (32 - 13))) + cc;
			a = (a << 10) | (a >> (32 - 10));
			cc += data[3] + C3 + ((dd & a) | (ee & ~a));
			cc = ((cc << 15) | (cc >> (32 - 15))) + bb;
			ee = (ee << 10) | (ee >> (32 - 10));
			bb += data[7] + C3 + ((cc & ee) | (dd & ~ee));
			bb = ((bb << 7) | (bb >> (32 - 7))) + a;
			dd = (dd << 10) | (dd >> (32 - 10));
			a += data[0] + C3 + ((bb & dd) | (cc & ~dd));
			a = ((a << 12) | (a >> (32 - 12))) + ee;
			cc = (cc << 10) | (cc >> (32 - 10));
			ee += data[13] + C3 + ((a & cc) | (bb & ~cc));
			ee = ((ee << 8) | (ee >> (32 - 8))) + dd;
			bb = (bb << 10) | (bb >> (32 - 10));
			dd += data[5] + C3 + ((ee & bb) | (a & ~bb));
			dd = ((dd << 9) | (dd >> (32 - 9))) + cc;
			a = (a << 10) | (a >> (32 - 10));
			cc += data[10] + C3 + ((dd & a) | (ee & ~a));
			cc = ((cc << 11) | (cc >> (32 - 11))) + bb;
			ee = (ee << 10) | (ee >> (32 - 10));
			bb += data[14] + C3 + ((cc & ee) | (dd & ~ee));
			bb = ((bb << 7) | (bb >> (32 - 7))) + a;
			dd = (dd << 10) | (dd >> (32 - 10));
			a += data[15] + C3 + ((bb & dd) | (cc & ~dd));
			a = ((a << 7) | (a >> (32 - 7))) + ee;
			cc = (cc << 10) | (cc >> (32 - 10));
			ee += data[8] + C3 + ((a & cc) | (bb & ~cc));
			ee = ((ee << 12) | (ee >> (32 - 12))) + dd;
			bb = (bb << 10) | (bb >> (32 - 10));
			dd += data[12] + C3 + ((ee & bb) | (a & ~bb));
			dd = ((dd << 7) | (dd >> (32 - 7))) + cc;
			a = (a << 10) | (a >> (32 - 10));
			cc += data[4] + C3 + ((dd & a) | (ee & ~a));
			cc = ((cc << 6) | (cc >> (32 - 6))) + bb;
			ee = (ee << 10) | (ee >> (32 - 10));
			bb += data[9] + C3 + ((cc & ee) | (dd & ~ee));
			bb = ((bb << 15) | (bb >> (32 - 15))) + a;
			dd = (dd << 10) | (dd >> (32 - 10));
			a += data[1] + C3 + ((bb & dd) | (cc & ~dd));
			a = ((a << 13) | (a >> (32 - 13))) + ee;
			cc = (cc << 10) | (cc >> (32 - 10));
			ee += data[2] + C3 + ((a & cc) | (bb & ~cc));
			ee = ((ee << 11) | (ee >> (32 - 11))) + dd;
			bb = (bb << 10) | (bb >> (32 - 10));

			d += data[3] + C4 + ((e | ~aa) ^ bb);
			d = ((d << 11) | (d >> (32 - 11))) + c;
			aa = (aa << 10) | (aa >> (32 - 10));
			c += data[10] + C4 + ((d | ~e) ^ aa);
			c = ((c << 13) | (c >> (32 - 13))) + bb;
			e = (e << 10) | (e >> (32 - 10));
			bb += data[14] + C4 + ((c | ~d) ^ e);
			bb = ((bb << 6) | (bb >> (32 - 6))) + aa;
			d = (d << 10) | (d >> (32 - 10));
			aa += data[4] + C4 + ((bb | ~c) ^ d);
			aa = ((aa << 7) | (aa >> (32 - 7))) + e;
			c = (c << 10) | (c >> (32 - 10));
			e += data[9] + C4 + ((aa | ~bb) ^ c);
			e = ((e << 14) | (e >> (32 - 14))) + d;
			bb = (bb << 10) | (bb >> (32 - 10));
			d += data[15] + C4 + ((e | ~aa) ^ bb);
			d = ((d << 9) | (d >> (32 - 9))) + c;
			aa = (aa << 10) | (aa >> (32 - 10));
			c += data[8] + C4 + ((d | ~e) ^ aa);
			c = ((c << 13) | (c >> (32 - 13))) + bb;
			e = (e << 10) | (e >> (32 - 10));
			bb += data[1] + C4 + ((c | ~d) ^ e);
			bb = ((bb << 15) | (bb >> (32 - 15))) + aa;
			d = (d << 10) | (d >> (32 - 10));
			aa += data[2] + C4 + ((bb | ~c) ^ d);
			aa = ((aa << 14) | (aa >> (32 - 14))) + e;
			c = (c << 10) | (c >> (32 - 10));
			e += data[7] + C4 + ((aa | ~bb) ^ c);
			e = ((e << 8) | (e >> (32 - 8))) + d;
			bb = (bb << 10) | (bb >> (32 - 10));
			d += data[0] + C4 + ((e | ~aa) ^ bb);
			d = ((d << 13) | (d >> (32 - 13))) + c;
			aa = (aa << 10) | (aa >> (32 - 10));
			c += data[6] + C4 + ((d | ~e) ^ aa);
			c = ((c << 6) | (c >> (32 - 6))) + bb;
			e = (e << 10) | (e >> (32 - 10));
			bb += data[13] + C4 + ((c | ~d) ^ e);
			bb = ((bb << 5) | (bb >> (32 - 5))) + aa;
			d = (d << 10) | (d >> (32 - 10));
			aa += data[11] + C4 + ((bb | ~c) ^ d);
			aa = ((aa << 12) | (aa >> (32 - 12))) + e;
			c = (c << 10) | (c >> (32 - 10));
			e += data[5] + C4 + ((aa | ~bb) ^ c);
			e = ((e << 7) | (e >> (32 - 7))) + d;
			bb = (bb << 10) | (bb >> (32 - 10));
			d += data[12] + C4 + ((e | ~aa) ^ bb);
			d = ((d << 5) | (d >> (32 - 5))) + c;
			aa = (aa << 10) | (aa >> (32 - 10));

			dd += data[15] + C5 + ((ee | ~a) ^ b);
			dd = ((dd << 9) | (dd >> (32 - 9))) + cc;
			a = (a << 10) | (a >> (32 - 10));
			cc += data[5] + C5 + ((dd | ~ee) ^ a);
			cc = ((cc << 7) | (cc >> (32 - 7))) + b;
			ee = (ee << 10) | (ee >> (32 - 10));
			b += data[1] + C5 + ((cc | ~dd) ^ ee);
			b = ((b << 15) | (b >> (32 - 15))) + a;
			dd = (dd << 10) | (dd >> (32 - 10));
			a += data[3] + C5 + ((b | ~cc) ^ dd);
			a = ((a << 11) | (a >> (32 - 11))) + ee;
			cc = (cc << 10) | (cc >> (32 - 10));
			ee += data[7] + C5 + ((a | ~b) ^ cc);
			ee = ((ee << 8) | (ee >> (32 - 8))) + dd;
			b = (b << 10) | (b >> (32 - 10));
			dd += data[14] + C5 + ((ee | ~a) ^ b);
			dd = ((dd << 6) | (dd >> (32 - 6))) + cc;
			a = (a << 10) | (a >> (32 - 10));
			cc += data[6] + C5 + ((dd | ~ee) ^ a);
			cc = ((cc << 6) | (cc >> (32 - 6))) + b;
			ee = (ee << 10) | (ee >> (32 - 10));
			b += data[9] + C5 + ((cc | ~dd) ^ ee);
			b = ((b << 14) | (b >> (32 - 14))) + a;
			dd = (dd << 10) | (dd >> (32 - 10));
			a += data[11] + C5 + ((b | ~cc) ^ dd);
			a = ((a << 12) | (a >> (32 - 12))) + ee;
			cc = (cc << 10) | (cc >> (32 - 10));
			ee += data[8] + C5 + ((a | ~b) ^ cc);
			ee = ((ee << 13) | (ee >> (32 - 13))) + dd;
			b = (b << 10) | (b >> (32 - 10));
			dd += data[12] + C5 + ((ee | ~a) ^ b);
			dd = ((dd << 5) | (dd >> (32 - 5))) + cc;
			a = (a << 10) | (a >> (32 - 10));
			cc += data[2] + C5 + ((dd | ~ee) ^ a);
			cc = ((cc << 14) | (cc >> (32 - 14))) + b;
			ee = (ee << 10) | (ee >> (32 - 10));
			b += data[10] + C5 + ((cc | ~dd) ^ ee);
			b = ((b << 13) | (b >> (32 - 13))) + a;
			dd = (dd << 10) | (dd >> (32 - 10));
			a += data[0] + C5 + ((b | ~cc) ^ dd);
			a = ((a << 13) | (a >> (32 - 13))) + ee;
			cc = (cc << 10) | (cc >> (32 - 10));
			ee += data[4] + C5 + ((a | ~b) ^ cc);
			ee = ((ee << 7) | (ee >> (32 - 7))) + dd;
			b = (b << 10) | (b >> (32 - 10));
			dd += data[13] + C5 + ((ee | ~a) ^ b);
			dd = ((dd << 5) | (dd >> (32 - 5))) + cc;
			a = (a << 10) | (a >> (32 - 10));

			cc += data[1] + C6 + ((d & aa) | (e & ~aa));
			cc = ((cc << 11) | (cc >> (32 - 11))) + bb;
			e = (e << 10) | (e >> (32 - 10));
			bb += data[9] + C6 + ((cc & e) | (d & ~e));
			bb = ((bb << 12) | (bb >> (32 - 12))) + aa;
			d = (d << 10) | (d >> (32 - 10));
			aa += data[11] + C6 + ((bb & d) | (cc & ~d));
			aa = ((aa << 14) | (aa >> (32 - 14))) + e;
			cc = (cc << 10) | (cc >> (32 - 10));
			e += data[10] + C6 + ((aa & cc) | (bb & ~cc));
			e = ((e << 15) | (e >> (32 - 15))) + d;
			bb = (bb << 10) | (bb >> (32 - 10));
			d += data[0] + C6 + ((e & bb) | (aa & ~bb));
			d = ((d << 14) | (d >> (32 - 14))) + cc;
			aa = (aa << 10) | (aa >> (32 - 10));
			cc += data[8] + C6 + ((d & aa) | (e & ~aa));
			cc = ((cc << 15) | (cc >> (32 - 15))) + bb;
			e = (e << 10) | (e >> (32 - 10));
			bb += data[12] + C6 + ((cc & e) | (d & ~e));
			bb = ((bb << 9) | (bb >> (32 - 9))) + aa;
			d = (d << 10) | (d >> (32 - 10));
			aa += data[4] + C6 + ((bb & d) | (cc & ~d));
			aa = ((aa << 8) | (aa >> (32 - 8))) + e;
			cc = (cc << 10) | (cc >> (32 - 10));
			e += data[13] + C6 + ((aa & cc) | (bb & ~cc));
			e = ((e << 9) | (e >> (32 - 9))) + d;
			bb = (bb << 10) | (bb >> (32 - 10));
			d += data[3] + C6 + ((e & bb) | (aa & ~bb));
			d = ((d << 14) | (d >> (32 - 14))) + cc;
			aa = (aa << 10) | (aa >> (32 - 10));
			cc += data[7] + C6 + ((d & aa) | (e & ~aa));
			cc = ((cc << 5) | (cc >> (32 - 5))) + bb;
			e = (e << 10) | (e >> (32 - 10));
			bb += data[15] + C6 + ((cc & e) | (d & ~e));
			bb = ((bb << 6) | (bb >> (32 - 6))) + aa;
			d = (d << 10) | (d >> (32 - 10));
			aa += data[14] + C6 + ((bb & d) | (cc & ~d));
			aa = ((aa << 8) | (aa >> (32 - 8))) + e;
			cc = (cc << 10) | (cc >> (32 - 10));
			e += data[5] + C6 + ((aa & cc) | (bb & ~cc));
			e = ((e << 6) | (e >> (32 - 6))) + d;
			bb = (bb << 10) | (bb >> (32 - 10));
			d += data[6] + C6 + ((e & bb) | (aa & ~bb));
			d = ((d << 5) | (d >> (32 - 5))) + cc;
			aa = (aa << 10) | (aa >> (32 - 10));
			cc += data[2] + C6 + ((d & aa) | (e & ~aa));
			cc = ((cc << 12) | (cc >> (32 - 12))) + bb;
			e = (e << 10) | (e >> (32 - 10));

			c += data[8] + C7 + ((dd & ee) | (~dd & a));
			c = ((c << 15) | (c >> (32 - 15))) + b;
			ee = (ee << 10) | (ee >> (32 - 10));
			b += data[6] + C7 + ((c & dd) | (~c & ee));
			b = ((b << 5) | (b >> (32 - 5))) + a;
			dd = (dd << 10) | (dd >> (32 - 10));
			a += data[4] + C7 + ((b & c) | (~b & dd));
			a = ((a << 8) | (a >> (32 - 8))) + ee;
			c = (c << 10) | (c >> (32 - 10));
			ee += data[1] + C7 + ((a & b) | (~a & c));
			ee = ((ee << 11) | (ee >> (32 - 11))) + dd;
			b = (b << 10) | (b >> (32 - 10));
			dd += data[3] + C7 + ((ee & a) | (~ee & b));
			dd = ((dd << 14) | (dd >> (32 - 14))) + c;
			a = (a << 10) | (a >> (32 - 10));
			c += data[11] + C7 + ((dd & ee) | (~dd & a));
			c = ((c << 14) | (c >> (32 - 14))) + b;
			ee = (ee << 10) | (ee >> (32 - 10));
			b += data[15] + C7 + ((c & dd) | (~c & ee));
			b = ((b << 6) | (b >> (32 - 6))) + a;
			dd = (dd << 10) | (dd >> (32 - 10));
			a += data[0] + C7 + ((b & c) | (~b & dd));
			a = ((a << 14) | (a >> (32 - 14))) + ee;
			c = (c << 10) | (c >> (32 - 10));
			ee += data[5] + C7 + ((a & b) | (~a & c));
			ee = ((ee << 6) | (ee >> (32 - 6))) + dd;
			b = (b << 10) | (b >> (32 - 10));
			dd += data[12] + C7 + ((ee & a) | (~ee & b));
			dd = ((dd << 9) | (dd >> (32 - 9))) + c;
			a = (a << 10) | (a >> (32 - 10));
			c += data[2] + C7 + ((dd & ee) | (~dd & a));
			c = ((c << 12) | (c >> (32 - 12))) + b;
			ee = (ee << 10) | (ee >> (32 - 10));
			b += data[13] + C7 + ((c & dd) | (~c & ee));
			b = ((b << 9) | (b >> (32 - 9))) + a;
			dd = (dd << 10) | (dd >> (32 - 10));
			a += data[9] + C7 + ((b & c) | (~b & dd));
			a = ((a << 12) | (a >> (32 - 12))) + ee;
			c = (c << 10) | (c >> (32 - 10));
			ee += data[7] + C7 + ((a & b) | (~a & c));
			ee = ((ee << 5) | (ee >> (32 - 5))) + dd;
			b = (b << 10) | (b >> (32 - 10));
			dd += data[10] + C7 + ((ee & a) | (~ee & b));
			dd = ((dd << 15) | (dd >> (32 - 15))) + c;
			a = (a << 10) | (a >> (32 - 10));
			c += data[14] + C7 + ((dd & ee) | (~dd & a));
			c = ((c << 8) | (c >> (32 - 8))) + b;
			ee = (ee << 10) | (ee >> (32 - 10));

			bb += data[4] + C8 + (cc ^ (dd | ~e));
			bb = ((bb << 9) | (bb >> (32 - 9))) + aa;
			dd = (dd << 10) | (dd >> (32 - 10));
			aa += data[0] + C8 + (bb ^ (cc | ~dd));
			aa = ((aa << 15) | (aa >> (32 - 15))) + e;
			cc = (cc << 10) | (cc >> (32 - 10));
			e += data[5] + C8 + (aa ^ (bb | ~cc));
			e = ((e << 5) | (e >> (32 - 5))) + dd;
			bb = (bb << 10) | (bb >> (32 - 10));
			dd += data[9] + C8 + (e ^ (aa | ~bb));
			dd = ((dd << 11) | (dd >> (32 - 11))) + cc;
			aa = (aa << 10) | (aa >> (32 - 10));
			cc += data[7] + C8 + (dd ^ (e | ~aa));
			cc = ((cc << 6) | (cc >> (32 - 6))) + bb;
			e = (e << 10) | (e >> (32 - 10));
			bb += data[12] + C8 + (cc ^ (dd | ~e));
			bb = ((bb << 8) | (bb >> (32 - 8))) + aa;
			dd = (dd << 10) | (dd >> (32 - 10));
			aa += data[2] + C8 + (bb ^ (cc | ~dd));
			aa = ((aa << 13) | (aa >> (32 - 13))) + e;
			cc = (cc << 10) | (cc >> (32 - 10));
			e += data[10] + C8 + (aa ^ (bb | ~cc));
			e = ((e << 12) | (e >> (32 - 12))) + dd;
			bb = (bb << 10) | (bb >> (32 - 10));
			dd += data[14] + C8 + (e ^ (aa | ~bb));
			dd = ((dd << 5) | (dd >> (32 - 5))) + cc;
			aa = (aa << 10) | (aa >> (32 - 10));
			cc += data[1] + C8 + (dd ^ (e | ~aa));
			cc = ((cc << 12) | (cc >> (32 - 12))) + bb;
			e = (e << 10) | (e >> (32 - 10));
			bb += data[3] + C8 + (cc ^ (dd | ~e));
			bb = ((bb << 13) | (bb >> (32 - 13))) + aa;
			dd = (dd << 10) | (dd >> (32 - 10));
			aa += data[8] + C8 + (bb ^ (cc | ~dd));
			aa = ((aa << 14) | (aa >> (32 - 14))) + e;
			cc = (cc << 10) | (cc >> (32 - 10));
			e += data[11] + C8 + (aa ^ (bb | ~cc));
			e = ((e << 11) | (e >> (32 - 11))) + dd;
			bb = (bb << 10) | (bb >> (32 - 10));
			dd += data[6] + C8 + (e ^ (aa | ~bb));
			dd = ((dd << 8) | (dd >> (32 - 8))) + cc;
			aa = (aa << 10) | (aa >> (32 - 10));
			cc += data[15] + C8 + (dd ^ (e | ~aa));
			cc = ((cc << 5) | (cc >> (32 - 5))) + bb;
			e = (e << 10) | (e >> (32 - 10));
			bb += data[13] + C8 + (cc ^ (dd | ~e));
			bb = ((bb << 6) | (bb >> (32 - 6))) + aa;
			dd = (dd << 10) | (dd >> (32 - 10));

			b += data[12] + (c ^ d ^ ee);
			b = ((b << 8) | (b >> (32 - 8))) + a;
			d = (d << 10) | (d >> (32 - 10));
			a += data[15] + (b ^ c ^ d);
			a = ((a << 5) | (a >> (32 - 5))) + ee;
			c = (c << 10) | (c >> (32 - 10));
			ee += data[10] + (a ^ b ^ c);
			ee = ((ee << 12) | (ee >> (32 - 12))) + d;
			b = (b << 10) | (b >> (32 - 10));
			d += data[4] + (ee ^ a ^ b);
			d = ((d << 9) | (d >> (32 - 9))) + c;
			a = (a << 10) | (a >> (32 - 10));
			c += data[1] + (d ^ ee ^ a);
			c = ((c << 12) | (c >> (32 - 12))) + b;
			ee = (ee << 10) | (ee >> (32 - 10));
			b += data[5] + (c ^ d ^ ee);
			b = ((b << 5) | (b >> (32 - 5))) + a;
			d = (d << 10) | (d >> (32 - 10));
			a += data[8] + (b ^ c ^ d);
			a = ((a << 14) | (a >> (32 - 14))) + ee;
			c = (c << 10) | (c >> (32 - 10));
			ee += data[7] + (a ^ b ^ c);
			ee = ((ee << 6) | (ee >> (32 - 6))) + d;
			b = (b << 10) | (b >> (32 - 10));
			d += data[6] + (ee ^ a ^ b);
			d = ((d << 8) | (d >> (32 - 8))) + c;
			a = (a << 10) | (a >> (32 - 10));
			c += data[2] + (d ^ ee ^ a);
			c = ((c << 13) | (c >> (32 - 13))) + b;
			ee = (ee << 10) | (ee >> (32 - 10));
			b += data[13] + (c ^ d ^ ee);
			b = ((b << 6) | (b >> (32 - 6))) + a;
			d = (d << 10) | (d >> (32 - 10));
			a += data[14] + (b ^ c ^ d);
			a = ((a << 5) | (a >> (32 - 5))) + ee;
			c = (c << 10) | (c >> (32 - 10));
			ee += data[0] + (a ^ b ^ c);
			ee = ((ee << 15) | (ee >> (32 - 15))) + d;
			b = (b << 10) | (b >> (32 - 10));
			d += data[3] + (ee ^ a ^ b);
			d = ((d << 13) | (d >> (32 - 13))) + c;
			a = (a << 10) | (a >> (32 - 10));
			c += data[9] + (d ^ ee ^ a);
			c = ((c << 11) | (c >> (32 - 11))) + b;
			ee = (ee << 10) | (ee >> (32 - 10));
			b += data[11] + (c ^ d ^ ee);
			b = ((b << 11) | (b >> (32 - 11))) + a;
			d = (d << 10) | (d >> (32 - 10));

			m_state[0] += aa;
			m_state[1] += bb;
			m_state[2] += cc;
			m_state[3] += dd;
			m_state[4] += ee;
			m_state[5] += a;
			m_state[6] += b;
			m_state[7] += c;
			m_state[8] += d;
			m_state[9] += e;
		}
	}
}