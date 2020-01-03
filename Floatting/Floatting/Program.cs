using System;
class Floattingpoint
    {   int [] arr1=new int[16];//creating arrays for individual storage of integer and decimal values;
        int [] arr2=new int[16];
        int [] arr3=new int[16];
        int [] arr4=new int[16];
        int [] arr5=new int[16];
        int [] arr6=new int[16];
        int carry;
        public void Integertobinary(int [] m,int a)//method for converting integer to binary
        {
            int A=Math.Abs(a),l=15;
            while(l>=0)
        {
            m[l--]=A%2;
            A=A/2;
        }
        }
        public void decimaltobinary(int [] n,float b)//method for converting decimal to binary
        {
            float B=Math.Abs(b);
            int l=0;
            while(l<16)
            {
                B=B*2;
                n[l++]=Math.Abs((int)B);
                B=B-n[l-1];
            }
        }
        public float binarytodecimal(int [] g,int [] k)//method for converting binary to decimal
        {
            float t=0,m=2;
            int s=0,i,l=1,j;
            for(i=15,j=0;i>=0;i--,j++)
            {
                s=s+g[i]*l;
                l=l*2;
                t=t+(float)k[j]/(float)m;
                m=m*2;
            }
            t=t+s;
            return t;
        }
        public void twoscompliment(int [] x,int [] o)//method for twos compliment
        { 
            int M=0,i;
            while(M<16)
            {
                if(x[M]==0)
                {
                    x[M]=1;
                }
               else{
                 x[M]=0;
               }
               if(o[M]==1)
                {
                 o[M]=0;
                }
                else
                {
                 o[M]=1;
                }
                M++;
            } 
            M=1;
            for(i=15;i>=0;i--) 
            {
                if(o[i]==1)
                    o[i]=0;
                else{
                    o[i]=1;
                    M=0;
                    break;
                }
                
            }
            if(M==1)
            {
               for(i=15;i>=0;i--) 
            {
                if(x[i]==1)
                x[i]=0;
                else{
                    x
                    [i]=1;
                    M=0;
                    break;
                }
            } 
            }
        }
        public void Binaryaddition(int [] s,int [] f,int [] g,int r)//method for binary addition
        { int u=15;
          while(u>=0)
          {
              if(Convert.ToBoolean(f[u])&& Convert.ToBoolean(g[u]))//conditional Statement for binary addition if the input is 1 and 1
              {
                 if(r==0)
                  {
                    s[u--]=0;    
                    r=1;
                    carry=r;
                  }
                  else
                  {
                    s[u--]=1;    
                    r=1;
                    carry=r;
                  }
              }
              else if((Convert.ToBoolean(f[u])&& (!Convert.ToBoolean(g[u]))) ||((!Convert.ToBoolean(f[u]))&& Convert.ToBoolean(g[u])))//conditional Statement for binary addition if the input is 1 and 0 or o and 1
              {
                  if(r==0)
                  {
                    s[u--]=1;    
                    r=0;
                    carry=r;
                  }
                  else
                  {
                    s[u--]=0;    
                    r=1;
                    carry=r;
                  }
              }
              else if((!Convert.ToBoolean(f[u])&& (!Convert.ToBoolean(g[u]))))//conditional Statement for binary addition if the input is 0 and 0
              {
                   if(r==0)
                  {
                    s[u--]=0;   
                    r=0;
                    carry=r;
                  }
                  else
                  {
                    s[u--]=1;   
                    r=0;    
                    carry=r;
                  }
              }
          }
        }
        public void Answer()//method to display binary values of all float and the binary addition values
        {
            int l=0;
            Console.Write("float 1 in binary:");//binary value for the first float input
            while(l<16)
            {
                Console.Write("{0}",arr1[l++]);
            }l=0;
            Console.Write(".");
            while(l<16)
            {
                Console.Write("{0}",arr3[l++]);
            }l=0;
            Console.WriteLine();
             Console.Write("float 2 in binary:");//binary value for the Second float input
            while(l<16)
            {
                Console.Write("{0}",arr2[l++]);
            }l=0;
            Console.Write(".");
            while(l<16)
            {
                Console.Write("{0}",arr4[l++]);
            }l=0;
            Console.WriteLine();
            Console.Write("sum in binary:");//Binary value for the sum of two float values
             while(l<16)
            {
                Console.Write("{0}",arr6[l++]);
            }l=0;
            Console.Write(".");
            while(l<16)
            {
                Console.Write("{0}",arr5[l++]);
            }
            Console.WriteLine();
            Console.Read();
        }
        static void Main(string[] args)
        {
            float f1,f2,f3,f4,res;
            int s1,s2,flag=0;
            Console.WriteLine("Enter Floating point 1:");//taking float input from user
            f1=float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Floating point 2:");
            f2=float.Parse(Console.ReadLine());
            s1=(int)f1;//seperating integer and fraction part from float input
            f3=f1-s1;//calculating fractional part for the first float input
            s2=(int)f2;//seperating integer and fraction part from float input
            f4=f2-s2;//calculating fractional part for the first float input
            Floattingpoint k=new Floattingpoint();
            k.carry=0;
            k.Integertobinary(k.arr1,s1);//conversion of integer part of f1 i.e s1 into binary
            k.Integertobinary(k.arr2,s2);//conversion of integer part of f2 i.e s1 into binary
            k.decimaltobinary(k.arr3,f3);//conversion of fraction part of f1 i.e s1 into binary
            k.decimaltobinary(k.arr4,f4);//conversion of fraction part of f2 i.e s1 into binary
            if(f1<0.0){//two's compliment representation for the float input if it is negative
                k.twoscompliment(k.arr1,k.arr3);
            }
            if(f2<0.0){
                k.twoscompliment(k.arr2,k.arr4);
            }
            k.Binaryaddition(k.arr5,k.arr3,k.arr4,k.carry);
            k.Binaryaddition(k.arr6,k.arr1,k.arr2,k.carry);
            if(k.arr6[0]==1)
            {
                flag=1;
                k.twoscompliment(k.arr6,k.arr5);
            }
             res=k.binarytodecimal(k.arr6,k.arr5);
             if(flag==0)
             Console.WriteLine("sum={0}",res);
             else
             {
                Console.WriteLine("sum=-{0}",res); 
             }
            k.Answer();
        }
}
