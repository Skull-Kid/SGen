using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SGen
{
	public class opt_fixed 
	{
		public opt_fixed ()
		{
			
		}
		//Used if select the first option at the gui

		//num FINISHED
		//WRITES IN A FILE ALL THA COMBINATIONS FROM THE len. Example: len = 6, will write from 000000 to 999999 both included
		public void num(double len, string dic_nam) 
		{
			StreamWriter sw = new StreamWriter(dic_nam, true);
			sw.AutoFlush = true;

			double max = 0;
			string s = "0";

			for (double i = 0; i < len; i++) {
				s += "9";
			}
			max = Convert.ToDouble (s);

			for (double i = 0; i <= max; i++) {
				s = Convert.ToString (i);
				while (len != s.Length) {
					s = "0" + s;
				}
				sw.Write (MainClass.prefix);
				sw.Write (s);
				sw.WriteLine (MainClass.suffix);
			}
			sw.Close ();
		}// END num

		//string source_az = "abcdefghijklmnopqrstuvwxyz";   
		//string source_azñ = "abcdefghijklmnñopqrstuvwxyz"; 
		//private static char[] base26Chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();


		// a_z FINISHED
		public void a_z(int len, string dic_nam) {
			StreamWriter sw = new StreamWriter (dic_nam, true);
			sw.AutoFlush = true;

			char startChar = 'a'; 
			char endChar = 'z';
			int numChars = endChar - startChar + 1;
			var s = new String(startChar, len).ToCharArray();   

			for (double it = 1; it <= Math.Pow(numChars, len); ++it) 
			{        
				sw.Write (MainClass.prefix);
				sw.Write (s);
				sw.WriteLine (MainClass.suffix);
				for (int ix = 0; ix < s.Length; ++ix) 
					if (ix == 0 || it % Math.Pow(numChars, ix) == 0) 
						s[s.Length - 1 - ix] = (char)(startChar + (s[s.Length - 1 - ix] - startChar + 1) % numChars);
			}

			sw.Close ();
		}// END a_z

		//A_Z FINISHED
		public void A_Z(int len, string dic_nam) {
			StreamWriter sw = new StreamWriter (dic_nam, true);
			sw.AutoFlush = true;

			char startChar = 'A'; 
			char endChar = 'Z';
			int numChars = endChar - startChar + 1;
			var s = new String(startChar, len).ToCharArray();   


			for (double it = 1; it <= Math.Pow(numChars, len); ++it) 
			{        
				sw.Write (MainClass.prefix);
				sw.Write (s);
				sw.WriteLine (MainClass.suffix);
				for (int ix = 0; ix < s.Length; ++ix) 
					if (ix == 0 || it % Math.Pow(numChars, ix) == 0) 
						s[s.Length - 1 - ix] = (char)(startChar + (s[s.Length - 1 - ix] - startChar + 1) % numChars);
			}

			sw.Close ();
		}// END A_Z

		//ascii FINISHED
		//from ' ' to '~'
		public void ascii(int len, string dic_nam) {
			StreamWriter sw = new StreamWriter (dic_nam, true);
			sw.AutoFlush = true;

			char startChar = ' '; 
			char endChar = '~';
			int numChars = endChar - startChar + 1;
			var s = new String(startChar, len).ToCharArray();   


			for (double it = 1; it <= Math.Pow(numChars, len); ++it) 
			{        
				sw.Write (MainClass.prefix);
				sw.Write (s);
				sw.WriteLine (MainClass.suffix);
				for (int ix = 0; ix < s.Length; ++ix) 
					if (ix == 0 || it % Math.Pow(numChars, ix) == 0) 
						s[s.Length - 1 - ix] = (char)(startChar + (s[s.Length - 1 - ix] - startChar + 1) % numChars);
			}

			sw.Close ();
		}// END ascii


		// custom FINISHED
		public void custom(int len, string dic_nam) {
			StreamWriter sw = new StreamWriter (dic_nam, true);
			sw.AutoFlush = true;

			var q = MainClass.alphabet.Select(x => x.ToString());
			for (int i = 0; i < len - 1; i++)
				q = q.SelectMany(x => MainClass.alphabet, (x, y) => x + y);

			foreach (var item in q) {
				sw.Write (MainClass.prefix);
				sw.Write (item);
				sw.WriteLine (MainClass.suffix);
			}
			sw.Close ();
		}// END custom

	}
}

