using System;
using System.IO;
using System.Linq;

namespace SGen
{
	public class opt_between
	{
		public opt_between ()
		{
			
		}
		//Used if select the second option at the gui


		//num FINISHED
		public void num(int len_a, int len_b, string dic_nam)
		{
			StreamWriter sw = new StreamWriter(dic_nam, true);
			sw.AutoFlush = true;

			string ss = "";
			for (double e = 0; e < len_b; e++) {
				ss += "9";
			}
			double maxx = Convert.ToInt32 (ss);

			for (double j = len_a; j <= len_b; j++) {

				double max = 0;
				string s = "";
				for (double i = 0; i < j; i++) {
					s += "9";
				}
				max = Convert.ToInt32 (s);

				for (double i = 0; i <= max; i++) {
					s = Convert.ToString (i);
					while (j != s.Length) {
						s = "0" + s;
					}
					sw.Write (MainClass.prefix);
					sw.Write (s);
					sw.WriteLine (MainClass.suffix);
				}
			}
		}//END num


		// a_z FINISHED
		public void a_z(int len_a, int len_b, string dic_nam) {
			StreamWriter sw = new StreamWriter (dic_nam, true);
			sw.AutoFlush = true;

			char startChar = 'a'; 
			char endChar = 'z';
			int numChars = endChar - startChar + 1;
			  
			for (int i = len_a; i <= len_b; i++) {
				
				var s = new String(startChar, i).ToCharArray(); 
				for (double it = 1; it <= Math.Pow (numChars, i); ++it) {        
					sw.Write (MainClass.prefix);
					sw.Write (s);
					sw.WriteLine (MainClass.suffix);
					for (int ix = 0; ix < s.Length; ++ix) {
						if (ix == 0 || it % Math.Pow (numChars, ix) == 0)
							s [s.Length - 1 - ix] = (char)(startChar + (s [s.Length - 1 - ix] - startChar + 1) % numChars);
					}
				}
			}
			sw.Close ();
		}// END a_z

		//A_Z FINISHED
		public void A_Z(int len_a, int len_b, string dic_nam) {
			StreamWriter sw = new StreamWriter (dic_nam, true);
			sw.AutoFlush = true;

			char startChar = 'A'; 
			char endChar = 'Z';
			int numChars = endChar - startChar + 1;

			for (int i = len_a; i <= len_b; i++) {

				var s = new String(startChar, i).ToCharArray(); 
				for (double it = 1; it <= Math.Pow (numChars, i); ++it) {        
					sw.Write (MainClass.prefix);
					sw.Write (s);
					sw.WriteLine (MainClass.suffix);
					for (int ix = 0; ix < s.Length; ++ix) {
						if (ix == 0 || it % Math.Pow (numChars, ix) == 0)
							s [s.Length - 1 - ix] = (char)(startChar + (s [s.Length - 1 - ix] - startChar + 1) % numChars);
					}
				}
			}
			sw.Close ();
		}// END A_Z


		// ascii FINISHED
		//from ' ' to '~'
		public void ascii(int len_a, int len_b, string dic_nam) {
			StreamWriter sw = new StreamWriter (dic_nam, true);
			sw.AutoFlush = true;

			char startChar = ' '; 
			char endChar = '~';
			int numChars = endChar - startChar + 1;

			for (int i = len_a; i <= len_b; i++) {

				var s = new String(startChar, i).ToCharArray(); 
				for (double it = 1; it <= Math.Pow (numChars, i); ++it) {        
					sw.Write (MainClass.prefix);
					sw.Write (s);
					sw.WriteLine (MainClass.suffix);
					for (int ix = 0; ix < s.Length; ++ix) {
						if (ix == 0 || it % Math.Pow (numChars, ix) == 0)
							s [s.Length - 1 - ix] = (char)(startChar + (s [s.Length - 1 - ix] - startChar + 1) % numChars);
					}
				}
			}
			sw.Close ();
		}// END ascii

		// custom FINISHED
		public void custom(int len_a, int len_b, string dic_nam) {
			StreamWriter sw = new StreamWriter (dic_nam, true);
			sw.AutoFlush = true;

			for (int j = len_a; j <= len_b; j++) {

				var q = MainClass.alphabet.Select(x => x.ToString());
				for (int i = 0; i < j - 1; i++)
					q = q.SelectMany(x => MainClass.alphabet, (x, y) => x + y);

				foreach (var item in q) {
					sw.Write (MainClass.prefix);
					sw.Write (item);
					sw.WriteLine (MainClass.suffix);
				}
			}
			sw.Close ();
		}// END custom


	}// END CLASS
}

