using System;

namespace WSE2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool error = false; //에러 조건이 성립되면 bool을 true로 바꿔줌.
            int sum = new int(); //최종 출력된 숫자를 계산하기 위한 변수. 자동 초기화하여 sum = 0 상태.
            int mid = new int(); //입력받은 첫번째보다 두번째 수를 비교하여 뒷 수가 크면 오류 출력함.
            int Up_Num = new int(); // 다음 문자를 출력할때마다 Num_Su의 수를 올림. ex) arr[i]에서 i가 증가할때마다

            int[] Num_Su = new int[16]; //문자별 수를 나타냄. (로마숫자 법칙을 지키기 위함.- 작은 수 뒤에 큰수가 올수없는 법칙, 가장 적은 개수로 로마숫자를 표현해야 하는 법칙)
            char[] scan = new char[16]; //입력받은 수를 스캔함 => 입력받은 string Roma를 char형 scan에 한 문자씩 저장.
            int[] Num_sum = new int[16]; //입력받은 수를 더해 로마숫자 법칙 2를 지키기 위함. ( 모든 수는 가능한 가장 적은 개수의 로마 숫자들로 표현해야 하는 법칙)

            while (true)
            {

                Console.Write("숫자를 입력해주세요 : ");
                string Roma = Console.ReadLine();  //로마숫자 입력받기

                if (1 <= Roma.Length && Roma.Length <= 15) //입력받은 문자열의 길이가 1~15까지만 허락하는 if문
                {
                    char[] arr = Roma.ToCharArray(); //string Roma를 char배열로 형변환.

                    for (int i = 0; i < arr.Length; i++) //char 배열의 길이 만큼 switch-case문을  반복실행한다.
                    {
                        switch (arr[i]) //char 배열요소가 'I', 'V', 'X', 'L', 'C', 'D', 'M'에 따라 sum에 해당값을 더한다.
                        {
                            case 'I':
                                sum += 1;      //'I'의 해당하는 아라비아 숫자인 1을 sum에 더함.
                                Num_Su[i] = 1;  //arr[i]=='I'라면 Num_Su[i]를 1로 지정함.
                                scan[i] = 'I';  //scan[i]번째에 문자'I'를 저장.
                                Up_Num += 1;    //scan[i+1]로(다음문자로) 갔다라는걸 알려주기 위해 Up_Num에 1을 더함.
                                Num_sum[i] = 1;  //로마법칙2를 지키기 위해 필용한 int형 배열
                                break;
                            case 'V':
                                sum += 5;       //'V'의 해당하는 아라비아 숫자인 5을 sum에 더함.
                                Num_Su[i] = 2;  //arr[i]=='I'라면 Num_Su[i]를 2로 지정함.   
                                scan[i] = 'V';   //scan[i]번째에 문자'V'를 저장.
                                Up_Num += 1;
                                Num_sum[i] = 5;
                                break;
                            case 'X':
                                sum += 10;       //'X'의 해당하는 아라비아 숫자인 10을 sum에 더함.
                                Num_Su[i] = 3;  //arr[i]=='I'라면 Num_Su[i]를 3로 지정함.
                                scan[i] = 'X';   //scan[i]번째에 문자'X'를 저장.
                                Up_Num += 1;
                                Num_sum[i] = 10;
                                break;
                            case 'L':
                                sum += 50;       //'L'= 50을 sum에 더함.
                                Num_Su[i] = 4;  //arr[i]=='I'라면 Num_Su[i]를 4로 지정함.
                                scan[i] = 'L';   //scan[i]번째에 문자'L'를 저장.
                                Up_Num += 1;
                                Num_sum[i] = 50;
                                break;
                            case 'C':
                                sum += 100;       //'C'= 100을 sum에 더함.
                                Num_Su[i] = 5;  //arr[i]=='I'라면 Num_Su[i]를 5로 지정함.
                                scan[i] = 'C';   //scan[i]번째에 문자'C'를 저장.
                                Up_Num += 1;
                                Num_sum[i] = 100;
                                break;
                            case 'D':
                                sum += 500;       //'D'= 500을 sum에 더함.
                                Num_Su[i] = 6;  //arr[i]=='I'라면 Num_Su[i]를 6로 지정함.
                                scan[i] = 'D';   //scan[i]번째에 문자'D'를 저장.
                                Up_Num += 1;
                                Num_sum[i] = 500;
                                break;
                            case 'M':
                                sum += 1000;       //'M'= 1000을 sum에 더함.
                                Num_Su[i] = 7;  //arr[i]=='I'라면 Num_Su[i]를 7로 지정함.
                                scan[i] = 'M';   //scan[i]번째에 문자'M'를 저장.
                                Up_Num += 1;
                                Num_sum[i] = 1000;
                                break;
                            default: //'I','V','X','L','C','D','M'문자만 쓸 수 있게 작성함. 해당문자를 제외한 다른 문자를 쓸 경우, 에러문장이 출력됨.
                                error = true;
                                break;
                        }
                    }

                    //로마숫자 법칙 1 : 왼쪽부터 오른쪽으로 갈수록 큰수에서 작은수로 진행되어야 함.
                    for (int i = 0; i < scan.Length; i++) //입력받은 문자열의 길이까지
                    {
                        if (Num_Su[i] == 1 && Up_Num > 1 && Num_Su[i + 1] > 3 ||      //IX,IV를 제외한 IL~IM이면 오류 출력.
                            Num_Su[i] == 3 && Up_Num > 1 && Num_Su[i + 1] > 5 ||      //XL,XC를 제외한 XD~XM이면 오류 출력.
                            Num_Su[i] == 5 && Up_Num > 1 && Num_Su[i + 1] > 8 ||      //CD,CM을 제외하고 큰 수가 오류 출력. (M 이상의 로마숫자) - 이 문제에선 해당없음.
                            Num_Su[i] == 2 && Up_Num > 1 && Num_Su[i + 1] > 1 ||      //V 다음에 V~M이 오면 오류 출력.
                            Num_Su[i] == 4 && Up_Num > 1 && Num_Su[i + 1] > 3 ||      //L 다음에 L~M이 오면 오류 출력.
                            Num_Su[i] == 6 && Up_Num > 1 && Num_Su[i + 1] > 5) error = true;  //D 다음에 D~M이 오게 되면 오류 출력.

                    }

                    if (Roma.Contains("IV") || Roma.Contains("IX")) sum -= 2; //입력받은 Roma문자열에 "IV","IX"가 있다면 sum에서 2를 뺌.(IV==> 6-4)(IX==>11-9) 
                    if (Roma.Contains("XL") || Roma.Contains("XC")) sum -= 20; //입력받은 Roma문자열에 "XL","XC"가 있다면 sum에서 2를 뺌.(XL==> 60-40)(XC==>110-90) 
                    if (Roma.Contains("CD") || Roma.Contains("CM")) sum -= 200; //입력받은 Roma문자열에 "CD","CM"가 있다면 sum에서 2를 뺌.(CD==> 600-400)(CM==>1100-900) 

                    //로마숫자 법칙 2 : 모든 수는 가능한 가장 적은 개수의 로마 숫자들로 표현해야 한다.
                    if (Up_Num > 2) //입력받은 수가 3자리 이상이라면
                    {
                        for (int j = 0; j < Up_Num - 1; j++)
                        {
                            if (Num_sum[j] < Num_sum[j + 1])
                            {
                                mid = Num_sum[j] + Num_sum[j + 1];
                                if ((mid == 6 || mid == 11 || mid == 60 || mid == 110 || mid == 600 || mid == 1100) && Num_sum[j + 1] <= Num_sum[j + 2]) error = true;
                                //입력받은 숫자 중 4,9,40,90,400,900 가 포함된 경우, 그 다음 숫자가 그 전 숫자보다 크다면 에러메세지 출력. (EX. IXX, IVV ,XDD)
                            }
                            if (Num_Su[j] != 7 && !(Num_sum[j] == Num_sum[j + 1] || Num_sum[j] > Num_sum[j + 1]) && Num_Su[j] == Num_Su[j + 2]) error = true;
                            //입력받은 수에서 양쪽에 같은 수이며, 가운데 숫자가 앞숫자보다 크다면 에러메세지 출력.(EX. IVI,IXI)
                            //              "                   , 가운데 숫자가 앞숫자랑 같지 않다면 에러메세지 출력.(EX, III,XXX,CCC,MMM과 같은 경우는 에러가 아니기때문)
                        }
                    }
                }
                else error = true;
                if (sum > 3999) error = true; //1~3999 사이의 숫자만 처리하여 4000을 넘어가면 에러문장이 출력.
                if (error)
                {
                    Console.Write("에러가 났습니다. 다시 입력해주세요."); //error bool값이 true이면 에러 메세지 출력 
                    error = false;
                }
                else Console.Write("입력한 수 : " + sum); //false면 로마숫자를 숫자로 출력함.
                Console.WriteLine("\n"); //한 줄 공백만들기.
                sum=0;
            }
        }
    }
}
