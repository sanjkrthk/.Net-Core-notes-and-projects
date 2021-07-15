
Dependency Injection (DI) is a software design pattern.
 It allows us to develop loosely-coupled code.
 The intent of Dependency Injection is to make code maintainable.
 Dependency Injection helps to reduce the tight coupling among software components.
 Dependency Injection reduces the hard-coded dependencies among your classes by injecting those dependencies at run time instead of design time technically. 


====================================
Constructor Injection in C#
Construction injection is the most commonly used dependency pattern in Object Oriented Programming. The constructor injection normally has only one parameterized constructor, so in this constructor dependency there is no default constructor and we need to pass the specified value at the time of object creation. We can use the injection component anywhere within the class. It addresses the most common scenario where a class requires one or more dependencies.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_project
{
    public interface Iset
    {
        void print();
    }

    public class servic : Iset
    {
        public void print()
        {
            Console.WriteLine("print........");
        }
    }

    public class client
    {
        private Iset _set;

        public client(Iset serv)
        {
            this._set = serv;
        }
        
        public void run()
        {
            
            Console.WriteLine("start");
            this._set.print();
        }

        public void Print2()
        {
            this._set.print();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            client cn = new client(new servic());
            cn.run();
            cn.Print2();
            Console.ReadKey();
        }
    }
}



=================================


Property Injection in C#
 
We use constructor injection, but there are some cases where I need a parameter-less constructor so we need to use property injection.



public interface INofificationAction
{      
   void ActOnNotification(string message);
}
   class atul     {  
       INofificationAction task = null;
       public void notify(INofificationAction  at ,string messages)
       {  
       this.task = at;
       task.ActOnNotification(messages);    
       }     
   }
   class EventLogWriter : INofificationAction
   {
       public void ActOnNotification(string message)
       {
           // Write to event log here
       }
   }
   class Program
   {
       static void Main(string[] args)
       {
           //services srv = new services();
           //other oth = new other();
           //oth.run();
           //Console.WriteLine();
           EventLogWriter elw = new EventLogWriter();
           atul at = new atul();
           at.notify(elw, "to logg");
           Console.ReadKey();
       }
   }
   
   
   
   
   
   
   =======================
   Method Injection in C#
 
In method injection we need to pass the dependency in the method only. The entire class does not need the dependency, just the one method. I have a class with a method that has a dependency. I do not want to use constructor injection because then I would be creating the dependent object every time this class is instantiated and most of the methods do not need this dependent object.


   
   public interface Iset
    {
        void print();      
    }
    public class servic : Iset
    {
        public void print()
        {  
            Console.WriteLine("print........");          
        }      
    }
    public class client
    {
        private Iset _set;
        public void run(Iset serv)
        {  
            this._set = serv;
            Console.WriteLine("start");
            this._set.print();
        }      
    }
    class method
    {
        public static void Main()
        {
            client cn = new client();
            cn.run(new servic());
            Console.ReadKey();         
        }
    }