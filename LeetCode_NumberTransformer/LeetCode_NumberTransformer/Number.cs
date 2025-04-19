using System;

namespace WSE
{
    class Program
    {
        static void Main(string[] args)
        {
            int Name_Length_sum = 0; //입력한 이름의 모든 문자개수를 합하는 변수.
            int a = new int();  //문자열의 문자개수를 세는 변수

            for (int y = 0; y < args.Length; y++)//입력받은 문자열의 길이만큼 반복
            {
                a = args[y].Length; //각 문자열배열의 개수를 세서 a에 넣음.
                Name_Length_sum += a + 1; //a를 sum에 더함. 띄어쓰기도 포함시키기 위해 +1을 해줌. So Eun =7
            }
            for (int i = 0; i < Name_Length_sum + 1; i++) Console.Write("*"); //sum만큼 반복하기 위해 sum에 1를 더 더한 수만큼 반복하여 테두리를 만든다.

            Console.Write("\n*"); //이름 처음에 *를 붙여줌.
            for (int z = 0; z < args.Length; z++) //입력받은 문자열을 출력해주는 for문
            {
                Console.Write(args[z] + " "); //문자열을 출력해줌.
                if (z == 0) //만약 z가 0이라면 앞으로 한칸 가서(?) -을 넣어줌.(ex. So-Eun) -?)위에서 공백을 같이 출력해주기 때문에.
                    Console.Write("\b-");
                if (z == args.Length - 1) //마지막 문자열 뒤에 *를 추가해주기 위해 앞으로 한칸 이동 후 입력.
                    Console.Write("\b*");
            }
            Console.WriteLine();

            for (int i = 0; i < Name_Length_sum + 1; i++) Console.Write("*"); //테두리 생성코드

            Console.WriteLine();
            Num_calculate(); //수 계산 함수호출.
        }

        static void Num_calculate()
        {
            bool isstart = false; //true일때, 숫자계산을 함.
            int Num = new int(); //입력받은 숫자를 int형변환 시킨 변수
            int Num2 = new int(); // Num의 뒤집은 숫자를 나타내는 int형 변수
            int tensix = new int(); //입력한 숫자가 16진수일 때 int형변환 시킨 변수
            int two = new int(); //입력한 숫자가 2진수일 때 int형변환 시킨 변수



            Console.Write("숫자를 입력하세요 : ");
            string ary_num = Console.ReadLine();
            Console.WriteLine();

            ary_num = ary_num.Replace(",", ""); //입력한 string값 ary_num문자열에서 ,를 찾아 제거해준다,변경해준다

            if (ary_num.Contains("1") && ary_num.Contains("0") && !ary_num.Contains(".")) // 예를들어 입력받은 수가 10100라면, 10진수인지 2진수인지 확인하기 위함. 
            {
                Console.Write("10진수를 입력하셨나요, 2진수를 입력하셨나요? (숫자로만 입력해주세요.) ");
                string zi = Console.ReadLine(); //몇 진수인지 입력받음.
                if (zi == "10") //zi가 10일때, 10진수로 계산함.
                {
                    Num = Convert.ToInt32(ary_num); //문자열 ary_num을 Convert.ToInt32를 사용하여 int값으로 변환시킴.
                    isstart = true; //숫자 계산 시작하게 함. 

                }
                else if (zi == "2")//zi가 2일때, 2진수로 계산함.
                {
                    two = Convert.ToInt32(ary_num, 2); //문자열 ary_num을 Convert.ToInt32를 사용하여 int값으로 변환시킴.
                    Num = two; //10진수로 바꿔준 2진수를 Num변수에 넣음.
                    isstart = true; //숫자 계산 시작하게 함. 
                }
                else Console.Write("다시 입력해주세요."); //10과 2가 아닌 다른 문자나 숫자를 입력받았을 경우 에러 메세지 출력.
            }
            else if (!(ary_num.Contains("1") && ary_num.Contains("0"))) //1과 0으로만 입력된 수가 아닐 때 10진수이기 때문에 10진수로 계산.
            {
                try //입력받은 수가 10진수일때.
                {
                    Num = Convert.ToInt32(ary_num); //문자열 ary_num을 Convert.ToInt32를 사용하여 int값으로 변환시킴.
                    isstart = true; //숫자 계산 시작하게 함. 
                }
                catch (Exception j) //10진수가 아닐때 예외처리.
                {
                    try //입력받은 수가 16진수일때.
                    {
                        tensix = Convert.ToInt32(ary_num, 16); //문자열 ary_num을 Convert.ToInt32를 사용하여 int값으로 변환시킴.
                        Num = tensix; //10진수로 바꿔준 16진수를 Num변수에 넣음.
                        isstart = true; //숫자 계산 시작하게 함.
                    }
                    catch (Exception f) //입력받은 수가 10진수 ,16진수,2진수가 아닐 때 예외처리
                    {
                        Console.Write("예외가 발생했습니다. 다시 입력해주세요.");
                    }
                }
            }
            else Console.Write("예외가 발생했습니다. 다시 입력해주세요."); //1과 0이 포함된 소수라면 에러메세지 출력.





            if (isstart)
            {
                Console.WriteLine("1. 입력받은 숫자 : " + Num); //입력받은 숫자 출력하기
                if (Num < 0) //음수를 입력했을 때 예외처리.
                    Console.WriteLine("음수를 입력했습니다. 다시 입력해주세요.");
                else
                {
                    if (Num > 2147483647) //입력받은 숫자가 int값을 초과하면 출력.
                    {
                        Console.Write("예외가 발생했습니다. 다시 입력해주세요.");
                    }
                    else
                    {
                        string ary = Num.ToString(); //int값을 string으로 형변환
                        char[] arr = ary.ToCharArray(); //ToCharArray() : 문자배열로 변환하는 메소드
                                                        //문자열 ary을 문자배열 arr로 변환시킴.
                        Array.Reverse(arr); //문자배열 arr를 역전시켜라.
                        string ary_2 = new string(arr); //문자배열 arr을 문자열 ary로 다시 변환시킴.
                        try
                        {
                            bool success = Int32.TryParse(ary_2, out Num2); //자체적으로 예외처리를 핸들링한다.(int값을 넣어가는 경우, 소수를 입력한 경우)
                            Console.Write("2. 숫자 뒤집기 : "); //입력받은 숫자 뒤집기
                            Console.Write(Num2); //뒤집은 숫자 출력.
                            Console.WriteLine();

                            Console.WriteLine("3. 입력받은 숫자에 1111 더하기 : " + (Num + 1111)); //변환시킨 int값에 1111을 더한 후 출력.(입력받은 숫자)
                            Console.WriteLine("4. 뒤집은 숫자에 1111 더하기 : " + (Num2 + 1111)); //변환시킨 int값에 1111을 더한 후 출력.(뒤집어진 숫자)

                            int max = Num; //입력받은 Keep를 max값에 넣어줌.
                            if (max < Num2) //Num2와 비교하여 Num2가 크다면 max는 Num2가 되는거고 성립하지 않으면 max값은 처음 Num값이 되는 것임.
                            {
                                max = Num2; //max값을 Num2로 바꿔줌.
                                Console.WriteLine("5. 뒤집은 숫자와 입력받은 숫자중에 더 큰 숫자 : " + max); //큰 숫자 max 출력
                            }
                            else if (Num == Num2) //뒤집어도 숫자가 같을 때 출력해줌.(ex.5555)
                                Console.WriteLine("두 수가 같습니다.");
                        }
                        catch (Exception b)
                        {
                            Console.Write("예외가 발생했습니다. 다시 입력해주세요.");
                        }

                    }
                }

            }
        }

    }
}
