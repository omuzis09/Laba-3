using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3
{
        class TPoint
        {
            public int x, y;

            public TPoint(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        class MyClass
        {
            public static int count = 0;
            private int sum;
            public int x, y;
            static readonly long ID; //переменная только для чтения
            const int c = 15;

            public MyClass()
            {
          
                x = 0;
                y = 0;
           
            }

            private MyClass(int x, int y, int sum) //закрытый конструктор
            {
                count++;
                this.sum = (x + y) * (sum + c);
            }

            public MyClass(int x = 0, int y = 0)
            {
                count++;
                this.x = x;
                this.y = y;
            sum = x + y;
            }

            public MyClass(TPoint p)
            {
                count++;
                this.x = p.x;
                this.y = p.y;
            }

            static MyClass()                        // Статический конструктор, высызвается 1 раз
            {
                count++;
                ID = DateTime.Now.Ticks;
            }

            public int Property  
            {
                get
                {
                    return Property;
                }
                set
                {
                    if ((value > 0) && (value < 13))                // Тестовое условие
                    {
                        Property = value + 1;
                    }
                    else
                    {
                        Property = value;
                    }
                }
            }     

            public void Method(ref int i)
            {
                i = i + 44;
            }

            public void MethodOut(out int i)
            {
                i=4;
            }

            ~MyClass()                              // Деструктор [call on free memory] 
            {
                count--;
            }

            public override int GetHashCode()       // свой хэш
            {
                int unitCode;
                if (this.x == 0)
                    unitCode = 1;
                else unitCode = 2;
                return this.y + unitCode;
            }

            public static void DrawInfo(MyClass Obj)
            {
                Console.WriteLine("x = {0}, y = {1}, sum = {2}", Obj.x, Obj.y, Obj.sum);
            }

            public override bool Equals(System.Object obj) //сравниваем с нул
            {
                if (obj == null)
                {
                    return false;
                }

            // Если параметр не может быть отброшен в значение Point return false.
            MyClass p = obj as MyClass;
                if ((System.Object)p == null)
                {
                    return false;
                }

            // Return true если поля совпадают:
            return (x == p.x) && (y == p.y);
            }

            public static string ToString(System.Object obj)
            {
            
                if (obj == null)
                {
                    return "nul";
                }

            // Если параметр нельзя передать в точку return false.
            MyClass p = obj as MyClass;
                if ((System.Object)p == null)
                {
                    return "nul";
                }

                return p.x.ToString() + ":" + p.y.ToString();
            }
        }

        class SuperString
        {
            public string Value = "";

            public SuperString()
            {
                Value = " ";
            }

            public SuperString(string value)
            {
                this.Value = value;
            }

            public int GetLength()
            {
                return Value.Length;
            }

            public bool FindChar(char c)
            {
                for (int i = 0; i < GetLength(); i++)
                {
                    if (Value[i] == c)
                    return true;
                }
                return false;
            }

            public bool IsWord(string word)
            {
                string[] arrWord;
                arrWord = Value.Split();
                for (int i = 0; i < arrWord.Length; i++)
                {
                    if (word == arrWord[i]) return true;
                }
                return false;
            }

            public void Replace(char c1, char c2)
            {
                Value = Value.Replace(c1, c2);
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                MyClass x = new MyClass();
                int v = 13;
                x.Method(ref v);                                            
                Console.WriteLine("Значние после вызова ref: {0}", v);
                x.MethodOut(out v);
                Console.WriteLine("Значние после вызова out: {0}", v);  
                MyClass x1 = new MyClass(5, 3);
                MyClass.DrawInfo(x1);
                Console.WriteLine("Кол-во: {0}", MyClass.count);

                MyClass partial = new MyClass(3, 5);
                Console.WriteLine("Равенство x1 и частичное: {0}", x1.Equals(partial));
                Console.WriteLine("x1.ToString: {0}", MyClass.ToString(x1));
                Console.WriteLine("x1.GetType(): {0}", x1.GetType());

                MyClass[] arr = { new MyClass(), new MyClass(1, 1), new MyClass(new TPoint(2, 2)) };

                SuperString st = new SuperString("adskskdwlalssdaask");
                Console.WriteLine("SuperSt value = {0}", st.Value);
                st.Replace('a', 'e');
                Console.WriteLine("Replaces SuperSt value = {0}", st.Value);
                Console.WriteLine("найти char 'x': {0}", st.FindChar('x'));

                SuperString[] arrr = { new SuperString("qwe thyh dfd"), new SuperString("wefev dfders er"), new SuperString("asd ref dfd") };
                Console.Write("Value: ");
                for (int i = 0; i < 3; i++)
                {
                if (arrr[i].GetLength() > 5) Console.Write("'{0}'; ", arrr[i].Value);
                }
                Console.WriteLine();

                Console.Write("Value IsWord['dfd']: ");
                for (int i = 0; i < 3; i++)
                {
                if (arrr[i].IsWord("dfd")) Console.Write("'{0}'; ", arrr[i].Value);
                }
            Console.WriteLine();
           
            }
        }

}




