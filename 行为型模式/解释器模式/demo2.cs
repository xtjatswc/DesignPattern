/*
 * 用户： Administrator
 * 日期: 2018/11/5
 * 时间: 11:26
 */
using System;
using System.Collections.Generic;

/*
 * 这种写法相当于把非终结符解释器放到客户端去了，这样灵活一些
 */
namespace 解释器模式.demo2
{
	/// <summary>
	/// 解释器上下文环境类。用来存储解释器的上下文环境，比如需要解释的文法等。
	/// </summary>
	class Context
	{
		private int sum;
		public int Sum {
			get { return sum; }
			set { sum = value; }
		}
     
	}
	/// <summary>
	/// 解释器抽象类。
	/// </summary>
	abstract class AbstractExpreesion
	{
		public abstract void Interpret(Context context);
       
     
	}
	/// <summary>
	///   解释器具体实现类。自加
	/// </summary>
	class PlusExpression : AbstractExpreesion
	{
		public override void Interpret(Context context)
		{
			int sum = context.Sum;
			sum++;
			context.Sum = sum;
 
		}
	}
	/// <summary>
	///   解释器具体实现类。 自减
	/// </summary>
	class MinusExpression : AbstractExpreesion
	{
		public override void Interpret(Context context)
		{
			int sum = context.Sum;
			sum--;
			context.Sum = sum;
 
		}
	}
    
	class Program2
	{
		static void Main2(string[] args)
		{
			Context context = new Context();
			context.Sum = 10;
			List<AbstractExpreesion> list = new List<AbstractExpreesion>();
			//运行加法三次
			list.Add(new PlusExpression());
			list.Add(new PlusExpression());
			list.Add(new PlusExpression());
			//运行减法两次
			list.Add(new MinusExpression());
			list.Add(new MinusExpression());
			for (int i = 0; i < list.Count; i++) {
				AbstractExpreesion expression = list[i];
				expression.Interpret(context);
			}
			Console.WriteLine(context.Sum);
			Console.ReadLine();
			//得出结果为11
		}
	}
}
