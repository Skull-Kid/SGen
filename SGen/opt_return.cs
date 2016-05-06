using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SGen
{
	public class opt_return
	{
		public opt_return ()
		{

		}
		//Used if run the command without gui


		//num FINISHED
		//RETURNS. Example: len_a = 6 and len_b = 6, will write from 000000 to 999999 both included
		public System.Collections.Generic.IEnumerable<string> num(double len_a, double len_b)
		{
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
					yield return s;
				}
			}
		}//END numm

		//a_z
		public System.Collections.Generic.IEnumerable<string> a_z(int len_a, int len_b) {
			char startChar = 'a'; 
			char endChar = 'z';
			int numChars = endChar - startChar + 1;

			for (int i = len_a; i <= len_b; i++) {
				string ss;
				var s = new String(startChar, i).ToCharArray(); 
				for (double it = 1; it <= Math.Pow (numChars, i); ++it) {  
					ss = new string (s);
					yield return ss;
					for (int ix = 0; ix < s.Length; ++ix) {
						if (ix == 0 || it % Math.Pow (numChars, ix) == 0)
							s [s.Length - 1 - ix] = (char)(startChar + (s [s.Length - 1 - ix] - startChar + 1) % numChars);
					}
				}
			}
		}// END a_z


		//A_Z
		public System.Collections.Generic.IEnumerable<string> A_Z(int len_a, int len_b) {
			char startChar = 'A'; 
			char endChar = 'Z';
			int numChars = endChar - startChar + 1;

			for (int i = len_a; i <= len_b; i++) {
				string ss;
				var s = new String(startChar, i).ToCharArray(); 
				for (double it = 1; it <= Math.Pow (numChars, i); ++it) {  
					ss = new string (s);
					yield return ss;
					for (int ix = 0; ix < s.Length; ++ix) {
						if (ix == 0 || it % Math.Pow (numChars, ix) == 0)
							s [s.Length - 1 - ix] = (char)(startChar + (s [s.Length - 1 - ix] - startChar + 1) % numChars);
					}
				}
			}
		}// END A_Z

		//ascii FINISHED
		//from ' ' to '~'
		public System.Collections.Generic.IEnumerable<string> ascii(int len_a, int len_b) {
			char startChar = ' '; 
			char endChar = '~';
			int numChars = endChar - startChar + 1;

			for (int i = len_a; i <= len_b; i++) {
				string ss;
				var s = new String(startChar, i).ToCharArray(); 
				for (double it = 1; it <= Math.Pow (numChars, i); ++it) {  
					ss = new string (s);
					yield return ss;
					for (int ix = 0; ix < s.Length; ++ix) {
						if (ix == 0 || it % Math.Pow (numChars, ix) == 0)
							s [s.Length - 1 - ix] = (char)(startChar + (s [s.Length - 1 - ix] - startChar + 1) % numChars);
					}
				}
			}
		}// END ascii


		// custom FINISHED
		public System.Collections.Generic.IEnumerable<string> custom(int len_a, int len_b) {
			string ss = "";
			for (int j = len_a; j <= len_b; j++) {
				var q = MainClass.alphabet.Select(x => x.ToString());
				for (int i = 0; i < j - 1; i++) {
					q = q.SelectMany (x => MainClass.alphabet, (x, y) => x + y);
				}


				foreach (var item in q) {
					ss = MainClass.prefix + item + MainClass.suffix;
					//ss = item;
					yield return ss;
				}

			}
		}// END custom

	}//END CLASS
}

