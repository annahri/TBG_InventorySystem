using System;
namespace HelperClass {
    public static class Helper {
		#region LinePrinting
        public static void NewLine(){
            Console.WriteLine();
        }

		public static void PrintLN(string str) {
			Console.WriteLine();
			Console.WriteLine(str);
			Console.WriteLine();
		}

		public static void PrintLN(string str,ConsoleColor color) {
			Console.WriteLine();
			Console.ForegroundColor = color;
			Console.WriteLine(str);
			Console.ResetColor();
			Console.WriteLine();
		}

		public static void PrintLN<T>(string str,T variable,ConsoleColor string_color,ConsoleColor variable_color) {
			Console.WriteLine();
			Console.ForegroundColor = string_color;
			Console.Write(str);
			Console.ResetColor();
			Console.ForegroundColor = variable_color;
			Console.WriteLine(variable);
			Console.ResetColor();
			Console.WriteLine();
		}

		public static void Print(string str) {
			Console.Write(str);
		}

		public static void Print(string str,ConsoleColor string_color) {
			Console.ForegroundColor = string_color;
			Console.Write(str);
			Console.ResetColor();
		}

		public static void Print(string str,string variable,ConsoleColor string_color,ConsoleColor variable_color) {
			Console.ForegroundColor = string_color;
			Console.Write(str);
			Console.ResetColor();
			Console.ForegroundColor = variable_color;
			Console.Write(variable);
			Console.ResetColor();
		}

		public static void PrintInb(string str1,string variable,string str2,ConsoleColor phrase_color,ConsoleColor variable_color) {
			Console.ForegroundColor = phrase_color;
			Console.Write(str1);
			Console.ResetColor();
			Console.ForegroundColor = variable_color;
			Console.Write(variable);
			Console.ResetColor();
			Console.ForegroundColor = phrase_color;
			Console.Write(str2);
			Console.ResetColor();
		}
		#endregion
	}
}
