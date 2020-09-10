
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RelOfPassword
{
	
	public partial class MainForm : Form
	{
		public MainForm()
		{
			
			InitializeComponent();
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			int L, U=0, S=0, j=0;
			string string1,string2;
			string sb = textBox1.Text;
			bool forRegisters = false, forSymbols = false, forNumbers = false;
			L = sb.Length;
			
			/*Если длина пароля L ≤ 4, то U=0
 			иначе, если 5 ≤ L ≤ 7, то U=6
 			иначе, если 8 ≤ L ≤ 15, то U=12
			иначе, если 16 ≤ L, то U=18 */
			
			//Длина пароля
			if(L <=4)
				U=0;
			if(L >= 5 && L <=7)
				U=6;
			if(L >= 8 && L <=15)
				U=12;
			if(L >=16)
				U=18;
			label2.Text = U.ToString();
			
			/* Если в пароле есть буквы, но только в одном (нижнем или верхнем регистре), то U=U+5
            иначе, если в пароле есть буквы и в нижнем и в верхнем регистрах, то U=U+7  */
			
			// Проверка на регистр
			string1 = sb.ToLower();
			string2 = sb.ToUpper();
			
			int result1 = String.Compare(sb, string1); 
			int result2 = String.Compare(sb, string2); 
			
			
			if(result1 == 0 || result2 == 0)
				U = U+5;
			else
			{
				U = U+7;
				forRegisters = true;
			}
			
			
			/* Пусть N - число цифр в пароле.
			Если число цифр в пароле 1 ≤ N ≤ 2, то U=U+5
 			иначе, если 3 ≤ N, то U=U+7 */
 			
 			//Проверка на наличие цифр
 			
 			for(int i = 0; i< sb.Length ; i++ )
 			{
 				if(sb[i] >= '0' && sb[i] <='9')
 					j++;
 				forNumbers = true;
 			}
 			
			if(j==1 || j==2)
				U = U+5;
			if(j>=3)
				U = U+7;
			
			
			
			/* Пусть S - число символов в пароле
            Если 1 ≤ S < 2, то U=U+5  #$%@
			иначе, если 2 ≤ S, то U=U+10 */ 
			
			//Проверка на наличие символов
			
			for(int i = 0; i< sb.Length ; i++ )
 			{
 				if(sb[i] == '#' || sb[i] =='$' || sb[i] =='%' || sb[i] =='@')
 					S++;
 				forSymbols = true;
 			}
			
			if(S== 0  || S ==1)
				U= U+5;
			else if(S>=2)
				U= U+10;
			
			/*Если в пароле есть буквы в обоих регистрах, спецсимволы и цифры, то U=U+6
     		иначе, если только чего-то одного из этого нет, U=U+4. */
			// Прoверка с условием &&
			
			if(forSymbols && forNumbers && forRegisters)
				U = U+6;
			else
				U = U+4;
			
			
			/*Если U < 16 - пароль очень слабый
			иначе, если 15 < U < 25 – слабый
			иначе, если 24< U < 35 – средний
			иначе, если 34< U < 45 – сильный
			иначе, если 44 < U – очень сильный */
			
			//Вывод результата на экран

			if(U<16)
				label2.Text ="пароль очень слабый U="+ U.ToString();
			if(U > 15 && U < 25)
				label2.Text ="пароль слабый U="+ U.ToString();
			if(U >= 25 && U < 35)
				label2.Text ="пароль средний U="+ U.ToString();
			if(U >= 35 && U < 45)
				label2.Text ="пароль сильный U="+ U.ToString();
			if(U>44)
				label2.Text ="пароль очень сильный U="+ U.ToString();
			
			
		
		}
	}
}
