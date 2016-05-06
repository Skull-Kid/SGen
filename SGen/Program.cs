using System;
using System.Diagnostics;

/*
 * STRING GENERATOR 06-08-2015
 * 
 * This program aims to be a complete string generator, with the possibility of write them to a file using the gui 
 * menu or get an output, using it directly with the args[], and redirecting the output with a pipe to other 
 * program without wasting space in our devices.
 * 
*/
namespace SGen
{
	class MainClass
	{
		public static string c_version = "1.0";

		public static string prefix = "";
		public static string suffix = "";

		//PIPE VARS
		public static double str_len_a = 6; //MIN LENGTH
		public static double str_len_b = 6; //MAX LENGTH
		public static bool s = false; //ASCII STANDAR TABLE, FROM ' ' to '~'
		//END PIPE VARS

		public static string alphabet = ""; //MAIN STRING, used to gen the strings

		public static opt_return ret = new opt_return();
		public static opt_between ob = new opt_between ();
		public static opt_fixed o = new opt_fixed ();

		//ARGS -h -v -g
		public static void Main (string[] args)
		{
			try{
				Console.WriteLine("");
				switch (args.Length) {
				case 0:
					for (int i = 0; i < 60; i++){Console.WriteLine ("");}
					Console.WriteLine ("");
					Console.WriteLine ("String Generator V" + c_version);
					Console.WriteLine ("");
					Console.WriteLine (" -g run gui");
					Console.WriteLine (" -h help, advanced use");
					Console.WriteLine (" -v version");

					break;
				case 1:
					switch (args[0]) {
					case "-h":
						help();
						break;
					case "-v":
						show_version();
						break;
					case "-g":
						run();
						break;
					default:
						for (int i = 0; i < 60; i++){Console.WriteLine ("");}
						Console.WriteLine ("");
						Console.WriteLine ("String Generator V" + c_version);
						Console.WriteLine ("");
						Console.WriteLine (" -g run gui");
						Console.WriteLine (" -h help, advanced use");
						Console.WriteLine (" -v version");
						break;
					}
					break;
				//PIPE USE
				case 5:
					//----------DIRECT USE CHECK
					if (args[0].Equals("-l")) //CHECK ARG 1, length option
					{
						try
						{
							if ((Convert.ToDouble(args[1]) <= Convert.ToDouble(args[2])) && (Convert.ToDouble(args[1])>0)) //CHECK ARGS 2 AND 3, length values
							{
								if(args[3].Equals("-o")) //CHECK ARG 4, options
								{
									if(args[4].Length <= 4) //CHECK Nº OF CHARS IN ARG 4, to custom the string
									{
										char[] ch = args[4].ToCharArray();

										for(int i = 0; i < ch.Length; i++) // CHECK CHARS FROM ARG 4, s option overwrite the others options
										{
											switch(ch[i]){
											case 'n':
												alphabet += "0123456789";
												break;
											case 'A':
												alphabet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
												break;
											case 'a':
												alphabet += "abcdefghijklmnopqrstuvwxyz";
												break;
											case 's'://Standar ASCII Table
												s = true;
												break;
											default:
												Console.WriteLine("");
												Console.WriteLine("WARNING: -o arg only can contain these chars aAns, current value: " + args[4]);
												Console.WriteLine("");
												return;
											}
										}

										str_len_a = Convert.ToDouble(args[1]);
										str_len_b = Convert.ToDouble(args[2]);

										try
										{
											if(s.Equals(true))
											{
												foreach (string x in MainClass.ret.ascii(Convert.ToInt32(str_len_a), Convert.ToInt32(str_len_b)))
												{
													Console.WriteLine(x);
												}
											}
											else{
												foreach (string x in MainClass.ret.custom(Convert.ToInt32(str_len_a), Convert.ToInt32(str_len_b)))
												{
													Console.WriteLine(x);
												}
											}
										}
										catch(Exception ex)
										{
											Console.WriteLine("");
											Console.WriteLine("");
											Console.WriteLine(ex.StackTrace);
										}

									}//END IF ARG 5
									else
									{
										Console.WriteLine("");
										Console.WriteLine("WARNING: Fifth arg max length is 4, ex. naAs, current length: " + args[4].Length);
										Console.WriteLine("");
									}
									
								}//END IF ARG 4
								else
								{
									if(args[3].Equals("-c")){
										alphabet = args[4].ToString();
										str_len_a = Convert.ToDouble(args[1]);
										str_len_b = Convert.ToDouble(args[2]);
										foreach (string x in MainClass.ret.custom(Convert.ToInt32(str_len_a), Convert.ToInt32(str_len_b)))
										{
											Console.WriteLine(x);
										}
									}

									else{
									Console.WriteLine("");
									Console.WriteLine("WARNING: Fourth arg must be -o or -c, current value: " + args[3]);
									Console.WriteLine("");
									}
								}

							}//END IF ARG 2 AND 3
							else
							{
								Console.WriteLine("WARNING: Second arg must be lower or equal than the third arg.");
								Console.WriteLine("");
								Console.WriteLine("Current values:");
								Console.WriteLine(" ARG 2:" + args[1]);
								Console.WriteLine(" ARG 3:" + args[2]);
								Console.WriteLine("");
							}
						}
						catch
						{
							Console.WriteLine("WARNING: 2 and 3 args must be numbers between 1 and 308, current values:");
							Console.WriteLine("");
							Console.WriteLine(" ARG 2:" + args[1]);
							Console.WriteLine(" ARG 3:" + args[2]);
							Console.WriteLine("");

						}

					}//END IF ARG 1
					else
					{
						Console.WriteLine("");
						Console.WriteLine("WARNING: first arg must be -l, current value ARG 1: " + args[0]);
						Console.WriteLine("");
					}
					//----------END DIRECT USE CHECK

					break;
				case 7: //prefix or suffix
					if (args[0].Equals("-l")) //CHECK ARG 1, length option
					{
						try
						{
							if ((Convert.ToDouble(args[1]) <= Convert.ToDouble(args[2])) && (Convert.ToDouble(args[1])>0)) //CHECK ARGS 2 AND 3, length values
							{
								if(args[3].Equals("-o")) //CHECK ARG 4, options
								{
									if(args[4].Length <= 4) //CHECK Nº OF CHARS IN ARG 4, to custom the string
									{
										char[] ch = args[4].ToCharArray();

										for(int i = 0; i < ch.Length; i++) // CHECK CHARS FROM ARG 4, s option overwrite the others options
										{
											switch(ch[i]){
											case 'n':
												alphabet += "0123456789";
												break;
											case 'A':
												alphabet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
												break;
											case 'a':
												alphabet += "abcdefghijklmnopqrstuvwxyz";
												break;
											case 's'://Standar ASCII Table
												s = true;
												break;
											default:
												Console.WriteLine("");
												Console.WriteLine("WARNING: -o arg only can contain these chars aAns, current value: " + args[4]);
												Console.WriteLine("");
												return;
											}
										}

										//check prefix or suffix
										if(args[5].Equals("-prefix")) //CHECK ARG 4, options
										{
											prefix = args[6];
										}
										else{
											if(args[5].Equals("-suffix")) //CHECK ARG 5, options
											{
												suffix = args[6];
											}
											else{
												Console.WriteLine("");
												Console.WriteLine("WARNING: 6 arg must be -prefix or -suffix, current: " + args[5]);
												Console.WriteLine("");
												return;
											}
										}

										str_len_a = Convert.ToDouble(args[1]);
										str_len_b = Convert.ToDouble(args[2]);

										try
										{
											if(s.Equals(true))
											{
												foreach (string x in MainClass.ret.ascii(Convert.ToInt32(str_len_a), Convert.ToInt32(str_len_b)))
												{
													Console.WriteLine(x);
												}
											}
											else{
												foreach (string x in MainClass.ret.custom(Convert.ToInt32(str_len_a), Convert.ToInt32(str_len_b)))
												{
													Console.WriteLine(x);
												}
											}
										}
										catch(Exception ex)
										{
											Console.WriteLine("");
											Console.WriteLine("");
											Console.WriteLine(ex.StackTrace);
										}

									}//END IF ARG 5
									else
									{
										Console.WriteLine("");
										Console.WriteLine("WARNING: Fifth arg max length is 4, ex. naAs, current length: " + args[4].Length);
										Console.WriteLine("");
									}

								}//END IF ARG 4
								else
								{
									if(args[3].Equals("-c")){
										//check prefix or suffix
										if(args[5].Equals("-prefix")) //CHECK ARG 4, options
										{
											prefix = args[6];
										}
										else{
											if(args[5].Equals("-suffix")) //CHECK ARG 5, options
											{
												suffix = args[6];
											}
											else{
												Console.WriteLine("");
												Console.WriteLine("WARNING: 6 arg must be -prefix or -suffix, current: " + args[5]);
												Console.WriteLine("");
												return;
											}
										}
										alphabet = args[4].ToString();
										str_len_a = Convert.ToDouble(args[1]);
										str_len_b = Convert.ToDouble(args[2]);
										foreach (string x in MainClass.ret.custom(Convert.ToInt32(str_len_a), Convert.ToInt32(str_len_b)))
										{
											Console.WriteLine(x);
										}
									}

									else{
										Console.WriteLine("");
										Console.WriteLine("WARNING: Fourth arg must be -o or -c, current value: " + args[3]);
										Console.WriteLine("");
									}
								}

							}//END IF ARG 2 AND 3
							else
							{
								Console.WriteLine("WARNING: Second arg must be lower or equal than the third arg.");
								Console.WriteLine("");
								Console.WriteLine("Current values:");
								Console.WriteLine(" ARG 2:" + args[1]);
								Console.WriteLine(" ARG 3:" + args[2]);
								Console.WriteLine("");
							}
						}
						catch
						{
							Console.WriteLine("WARNING: 2 and 3 args must be numbers between 1 and 308, current values:");
							Console.WriteLine("");
							Console.WriteLine(" ARG 2:" + args[1]);
							Console.WriteLine(" ARG 3:" + args[2]);
							Console.WriteLine("");

						}

					}//END IF ARG 1
					else
					{
						Console.WriteLine("");
						Console.WriteLine("WARNING: first arg must be -l, current value ARG 1: " + args[0]);
						Console.WriteLine("");
					}
					//----------END DIRECT USE CHECK

					break;
				case 9: //prefix and suffix
					if (args[0].Equals("-l")) //CHECK ARG 1, length option
					{
						try
						{
							if ((Convert.ToDouble(args[1]) <= Convert.ToDouble(args[2])) && (Convert.ToDouble(args[1])>0)) //CHECK ARGS 2 AND 3, length values
							{
								if(args[3].Equals("-o")) //CHECK ARG 4, options
								{
									if(args[4].Length <= 4) //CHECK Nº OF CHARS IN ARG 4, to custom the string
									{
										char[] ch = args[4].ToCharArray();

										for(int i = 0; i < ch.Length; i++) // CHECK CHARS FROM ARG 4, s option overwrite the others options
										{
											switch(ch[i]){
											case 'n':
												alphabet += "0123456789";
												break;
											case 'A':
												alphabet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
												break;
											case 'a':
												alphabet += "abcdefghijklmnopqrstuvwxyz";
												break;
											case 's'://Standar ASCII Table
												s = true;
												break;
											default:
												Console.WriteLine("");
												Console.WriteLine("WARNING: -o arg only can contain these chars aAns, current value: " + args[4]);
												Console.WriteLine("");
												return;
											}
										}

										//check prefix and suffix
										if((args[5].Equals("-prefix")) && (args[7].Equals("-suffix"))) //CHECK ARG 4, options
										{
											prefix = args[6];
											suffix = args[8];
										}
										else{
											Console.WriteLine("");
											Console.WriteLine("WARNING: 6 arg must be -prefix, current: " + args[5]);
											Console.WriteLine("WARNING: 8 arg must be -suffix, current: " + args[7]);
											Console.WriteLine("");
											return;
										}

										str_len_a = Convert.ToDouble(args[1]);
										str_len_b = Convert.ToDouble(args[2]);

										try
										{
											if(s.Equals(true))
											{
												foreach (string x in MainClass.ret.ascii(Convert.ToInt32(str_len_a), Convert.ToInt32(str_len_b)))
												{
													Console.WriteLine(x);
												}
											}
											else{
												foreach (string x in MainClass.ret.custom(Convert.ToInt32(str_len_a), Convert.ToInt32(str_len_b)))
												{
													Console.WriteLine(x);
												}
											}
										}
										catch(Exception ex)
										{
											Console.WriteLine("");
											Console.WriteLine("");
											Console.WriteLine(ex.StackTrace);
										}

									}//END IF ARG 5
									else
									{
										Console.WriteLine("");
										Console.WriteLine("WARNING: Fifth arg max length is 4, ex. naAs, current length: " + args[4].Length);
										Console.WriteLine("");
									}

								}//END IF ARG 4
								else
								{
									if(args[3].Equals("-c")){
										//check prefix and suffix
										if((args[5].Equals("-prefix")) && (args[7].Equals("-suffix"))) //CHECK ARG 4, options
										{
											prefix = args[6];
											suffix = args[8];
										}
										else{
											Console.WriteLine("");
											Console.WriteLine("WARNING: 6 arg must be -prefix, current: " + args[5]);
											Console.WriteLine("WARNING: 8 arg must be -suffix, current: " + args[7]);
											Console.WriteLine("");
											return;
										}
										alphabet = args[4].ToString();
										str_len_a = Convert.ToDouble(args[1]);
										str_len_b = Convert.ToDouble(args[2]);
										foreach (string x in MainClass.ret.custom(Convert.ToInt32(str_len_a), Convert.ToInt32(str_len_b)))
										{
											Console.WriteLine(x);
										}
									}

									else{
										Console.WriteLine("");
										Console.WriteLine("WARNING: Fourth arg must be -o or -c, current value: " + args[3]);
										Console.WriteLine("");
									}
								}

							}//END IF ARG 2 AND 3
							else
							{
								Console.WriteLine("WARNING: Second arg must be lower or equal than the third arg.");
								Console.WriteLine("");
								Console.WriteLine("Current values:");
								Console.WriteLine(" ARG 2:" + args[1]);
								Console.WriteLine(" ARG 3:" + args[2]);
								Console.WriteLine("");
							}
						}
						catch
						{
							Console.WriteLine("WARNING: 2 and 3 args must be numbers between 1 and 308, current values:");
							Console.WriteLine("");
							Console.WriteLine(" ARG 2:" + args[1]);
							Console.WriteLine(" ARG 3:" + args[2]);
							Console.WriteLine("");

						}

					}//END IF ARG 1
					else
					{
						Console.WriteLine("");
						Console.WriteLine("WARNING: first arg must be -l, current value ARG 1: " + args[0]);
						Console.WriteLine("");
					}
					//----------END DIRECT USE CHECK
					break;
				default:
					Console.WriteLine("");
					Console.WriteLine("WARNING: NOT ENOUGH ARGUMENTS");
					Console.WriteLine("");
					show_version();
					Console.WriteLine ("\nBasic usage: SGen [-g/-v/-h]\n");
					Console.WriteLine ("Advanced usage: SGen [-l x y] {[-o naAs] / [-c Custom_String]} [-prefix p] [-suffix s]\n");
					break;
				}

			}
			catch(Exception ex) {
				Console.WriteLine(ex.StackTrace);
			}
		}

		//ARG -g
		public static void run()
		{
			bool done = true;
			while (done) { //BIG WHILE

				//FIXED length
				double f_leng = 1; 

				//length BETWEEN 2 VALUES
				int b_leng_a = 1; //LOWER
				int b_leng_b = 1; //HIGHER

				for (int i = 0; i < 60; i++){Console.WriteLine ("");}

				string opt = ""; //FIRST MENU
				Console.WriteLine (" String length");
				Console.WriteLine ("  1-Fixed");
				Console.WriteLine ("  2-Between two values");
				Console.WriteLine ("  q-Quit\n");
				Console.Write ("--> ");
				opt = Console.ReadLine ();
				for (int i = 0; i < 60; i++){Console.WriteLine ("");}

				//SWITCH
				switch (opt) {
				case "1":
					Console.WriteLine ("Set fixed length, min 1 max 308");
					Console.Write ("--> ");
					try{
						f_leng = Convert.ToDouble (Console.ReadLine ());
					}
					catch{
						Console.WriteLine ("\nWARNING!!! Length, must be a number.");
						Console.WriteLine ("Press enter to retry.");
						Console.ReadLine();
						break;
					}

					while(true){
						//
						//SET FILE NAME AND GENERATING OPTIONS
						//
						for (int i = 0; i < 60; i++){Console.WriteLine ("");}
						Console.WriteLine ("WARNING: If you select an existing file, strings will be added to the end of it.");
						Console.WriteLine ("");
						Console.Write ("Dictionary name(ex. a-z.txt)> ");
						string d_name = "default.txt";
						string name = Console.ReadLine ();
						if (name.Equals ("")) {
							name = d_name;
						}
						for (int i = 0; i < 60; i++){Console.WriteLine ("");}
						Console.WriteLine ("File saved as: " + name);
						Console.WriteLine ("");
						bool t = true;
						while (t) {
							Console.WriteLine ("");
							Console.WriteLine ("      MENU");
							Console.WriteLine (" 1-Numeric 0-9");
							Console.WriteLine (" 2-LowerCase a-z");
							Console.WriteLine (" 3-UpperCase A-Z");
							Console.WriteLine (" 4-Standard ASCII Table");
							Console.WriteLine (" 5-Custom chars");
							Console.WriteLine (" 6-Set prefix");
							Console.WriteLine (" 7-Set suffix");
							Console.WriteLine (" 8-Set save name");
							Console.WriteLine (" q-Exit");
							Console.Write ("--> ");
							string opt2 = Console.ReadLine ();

							for (int i = 0; i < 60; i++) {Console.WriteLine ("");}
							Stopwatch stw = new Stopwatch();

							switch (opt2) {
							case "1":
								stw.Start();
								Console.WriteLine ("Generating...");
								o.num (f_leng, name);
								Console.WriteLine ("Finished");
								break;
							case "2":
								stw.Start();
								Console.WriteLine ("Generating...");
								o.a_z (Convert.ToInt32 (f_leng), name);
								Console.WriteLine ("Finished");
								break;
							case "3":
								stw.Start();
								Console.WriteLine ("Generating...");
								o.A_Z (Convert.ToInt32 (f_leng), name);
								Console.WriteLine ("Finished");
								break;
							case "4":
								stw.Start();
								Console.WriteLine ("Generating...");
								o.ascii (Convert.ToInt32 (f_leng), name);
								Console.WriteLine ("Finished");
								break;
							case "5":
								for (int i = 0; i < 60; i++) {Console.WriteLine ("");}
								custom ();
								for (int i = 0; i < 60; i++) {Console.WriteLine ("");}
								stw.Start();
								Console.WriteLine ("Generating...");
								o.custom(Convert.ToInt32 (f_leng), name);
								Console.WriteLine ("Finished");
								break;
							case "6":
								Console.Write (" Set prefix >");
								prefix = Console.ReadLine ();
								break;
							case "7":
								Console.Write (" Set suffix >");
								suffix = Console.ReadLine ();
								break;
							case "8":
								t = false;
								break;
							case "q":
								for (int i = 0; i < 60; i++) {Console.WriteLine ("");}
								show_version ();
								Console.Write (" Goodbye\n");
								return;
							default:
								break;
							}//END SWITCH
							if (stw.IsRunning.Equals (true)) {
								stw.Stop ();
								Console.WriteLine ("\n\nTime Elapsed = {0}", stw.Elapsed);
								Console.Write ("\n\nPress enter to continue . . .");
								Console.ReadLine ();
							}
						}//END WHILE

					}//END WHILE

				case "2":
					while (true) {
						try{
							Console.WriteLine ("Length between 2 values");
							Console.Write ("First value--> ");
							b_leng_a = Convert.ToInt32 (Console.ReadLine ());
							Console.Write ("Second value--> ");
							b_leng_b = Convert.ToInt32 (Console.ReadLine ());
							if ((b_leng_a >= b_leng_b) || (b_leng_a == 0)) {
								Console.WriteLine ("\n\nThe first value must be lower than the second\n");
								Console.WriteLine ("First value: " + b_leng_a);
								Console.WriteLine ("Second value: " + b_leng_b);
								Console.WriteLine ("\nValues can't be 0\n\n");
							} else {

								while(true){
									//
									//SET FILE NAME AND GENERATING OPTIONS
									//
									for (int i = 0; i < 60; i++){Console.WriteLine ("");}
									Console.WriteLine ("WARNING: If you select an existing file, strings will be added to the end of it.");
									Console.WriteLine ("");
									Console.Write ("Dictionary name(ex. a-z.txt)> ");
									string d_name2 = "default.txt";
									string name2 = Console.ReadLine ();
									if (name2.Equals ("")) {
										name2 = d_name2;
									}
									for (int i = 0; i < 60; i++){Console.WriteLine ("");}
									Console.WriteLine ("File saved as: " + name2);
									Console.WriteLine ("");
										bool t = true;
									while(t){
										Console.WriteLine ("");
										Console.WriteLine ("      MENU");
										Console.WriteLine (" 1-Numeric 0-9");
										Console.WriteLine (" 2-LowerCase a-z");
										Console.WriteLine (" 3-UpperCase A-Z");
										Console.WriteLine (" 4-Standard ASCII Table");
										Console.WriteLine (" 5-Custom chars");
										Console.WriteLine (" 6-Set prefix");
										Console.WriteLine (" 7-Set suffix");
										Console.WriteLine (" 8-Set save name");
										Console.WriteLine (" q-Exit");
										Console.WriteLine ("");
										Console.Write ("--> ");
										opt = Console.ReadLine ();

										for (int i = 0; i < 60; i++) {Console.WriteLine ("");}
										Stopwatch stw = new Stopwatch();

										switch (opt) {
										case "1":
											stw.Start();
											Console.WriteLine ("Generating...");
											ob.num (b_leng_a, b_leng_b, name2);
											Console.WriteLine ("Finished");
											break;
										case "2":
											stw.Start();
											Console.WriteLine ("Generating...");
											ob.a_z (b_leng_a, b_leng_b, name2);
											Console.WriteLine ("Finished");
											break;
										case "3":
											stw.Start();
											Console.WriteLine ("Generating...");
											ob.A_Z (b_leng_a, b_leng_b, name2);
											Console.WriteLine ("Finished");
											break;
										case "4":
											stw.Start();
											Console.WriteLine ("Generating...");
											ob.ascii (b_leng_a, b_leng_b, name2);
											Console.WriteLine ("Finished");
											break;
										case "5":
											for (int i = 0; i < 60; i++) {Console.WriteLine ("");}
											custom ();
											for (int i = 0; i < 60; i++) {Console.WriteLine ("");}
											stw.Start();
											Console.WriteLine ("Generating...");
											ob.custom(b_leng_a, b_leng_b, name2);
											Console.WriteLine ("Finished");
											break;
										case "6":
											Console.Write (" Set prefix >");
											prefix = Console.ReadLine ();
											break;
										case "7":
											Console.Write (" Set suffix >");
											suffix = Console.ReadLine ();
											break;
										case "8":
											t = false;
											break;
										case "q":
											for (int i = 0; i < 60; i++){Console.WriteLine ("");}
											show_version();
											Console.Write (" Goodbye\n");
											return;
										default:
											break;
										}//END SWITCH
										if (stw.IsRunning.Equals (true)) {
											stw.Stop ();
											Console.WriteLine ("\n\nTime Elapsed = {0}", stw.Elapsed);
											Console.Write ("\n\nPress enter to continue . . .");
											Console.ReadLine ();
										}
									}// END WHILE t
								
								}//END WHILE

							}//END ELSE
						}
						catch{
							Console.WriteLine ("\nWARNING!!! Length, must be a number.");
							Console.WriteLine ("Press enter to retry.");
							Console.ReadLine();
							break;
						}
					}//END WHILE
					break;
				case "q":
					for (int i = 0; i < 5; i++){Console.WriteLine ("");}
					Console.WriteLine ("String Generator V" + c_version);
					Console.WriteLine ("Goodbye");
					done = false;
					return;
				
				}//END SWITCH
			


			}//END BIG WHILE
		}//END run

		//ARG -v
		public static void show_version()
		{
			String v_info = "String Generator V" + c_version + "\n\n  Dev By Skull Kid\n";
			Console.WriteLine (v_info);
		}


		public static void custom()
		{
			Console.WriteLine ("String with the desired chars");
			Console.Write ("-->");
			string s = Console.ReadLine ();
			alphabet = s;
		}


		//ARG -h
		public static void help()
		{
			for (int i = 0; i < 60; i++){Console.WriteLine ("");}
			Console.WriteLine ("Basic usage: SGen [-g/-v/-h]");
			Console.WriteLine ("\n______________________________\n");
			Console.WriteLine (" -g: runs the gui to create custom dictionaries.");
			Console.WriteLine (" -v: shows version.");
			Console.WriteLine (" -h: shows this help.");
			Console.WriteLine ("______________________________\n\n\n\n");
			Console.Write ("Press enter to see the Advanced use, CTRL + C to quit");
			Console.ReadLine ();
			for (int i = 0; i < 60; i++){Console.WriteLine ("");}
			Console.WriteLine ("Advanced usage:");
			Console.WriteLine (" SGen [-l x y] {[-o naAs] / [-c Custom_String]} -prefix pre -sufix suf");
			Console.WriteLine ("\nThese options are to get an output and use a pipe '|' to redirect it to other \nprogram, also you can use '>' or '>>' to redirect to a file");
			Console.WriteLine ("______________________________");
			Console.WriteLine (" -l: length of the string - from x to y, both included");
			Console.WriteLine ("");
			Console.WriteLine ("First value must be lower or equal than the second value. First value can't be 0");
			Console.WriteLine ("______________________________");
			Console.WriteLine (" -o: string options - add a range of chars to the string generator");
			Console.WriteLine ("");
			Console.WriteLine (" n: numbers 0-9");
			Console.WriteLine (" a: chars a to z");
			Console.WriteLine (" A: chars A to Z");
			Console.WriteLine (" s: Standar ASCII Table: from \' \' to \'~\'");
			Console.WriteLine ("______________________________");
			Console.WriteLine ("-c: Custom string - add a custom string of chars.");

			Console.WriteLine ("______________________________\n");
			Console.WriteLine ("-prefix: set a prefix for all strings");
			Console.WriteLine ("-suffix: set a suffix for all strings");
			Console.WriteLine ("");
			Console.Write ("Press enter to see the examples, CTRL + C to quit");
			Console.ReadLine ();
			for (int i = 0; i < 60; i++){Console.WriteLine ("");}
			Console.WriteLine ("Examples: ");
			Console.WriteLine ("");
			Console.WriteLine (" SGen -l 6 6 -o n <- Returns all combinations from 000000-999999");
			Console.WriteLine (" SGen -l 5 5 -o A <- Returns all combinations from AAAAA-ZZZZZ");
			Console.WriteLine (" SGen -l 4 6 -o a <- Returns all combinations from aaaa-zzzz and aaaaa-zzzzz");
			Console.WriteLine (" SGen -l 4 4 -o aA <- Returns all combinations from aaaa-ZZZZ");
			Console.WriteLine (" SGen -l 4 4 -o Aa <- Returns all combinations from AAAA-zzzz");
			Console.WriteLine (" SGen -l 4 4 -c ABCDE <- Returns all combinations from AAAA-EEEE");
			Console.WriteLine (" SGen -l 4 4 -c edcba <- Returns all combinations from eeee-aaaa");
			Console.WriteLine (" SGen -l 8 8 -c 01 <- Returns all combinations from 00000000-11111111");
			Console.WriteLine (" SGen -l 8 8 -c 10 <- Returns all combinations from 11111111-00000000");
			Console.WriteLine (" SGen -l 4 4 -c 0123456789ABCDEF <- Returns all combinations from 0000-FFFF");
			Console.WriteLine (" SGen -l 2 3 -o n -prefix pre <- Returns all combinations from pre00-pre999");
			Console.WriteLine (" SGen -l 3 3 -o a -suffix suf <- Returns all combinations from aaasuf-zzzsuf");
			Console.WriteLine (" SGen -l 2 2 -c 01 -prefix pre -suffix suf");
			Console.WriteLine (" Returns all combinations from pre00suf-pre11suf");
			Console.WriteLine ("");
			Console.WriteLine (" Use \"\" to include space. Like: Sgen -l 2 2 -c \" abc\"");
			Console.Write ("\nPress enter to quit . . .");
			Console.ReadLine ();
			for (int i = 0; i < 60; i++){Console.WriteLine ("");}
		}

	}
}
