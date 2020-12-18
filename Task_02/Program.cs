/*
 * Oпределить абстрактный класс Animal. 
 * В классе описать поле «кличка животного», «возраст животного», методы 
 * доступа к полям. Снабдить класс Animal прототипами методов AnimalSound() - 
 * «звук животного» и AnimalInfo() – информация о животном 
 * (значения всех его полей). Описать два класса наследника 
 * от Animal. Класс Dog, описывающий собаку и класс Cow, описывающий корову. 
 * Класс Dog инкапсулирует поля «порода собаки» и логическое поле isTrained 
 * (true, если собака дрессирована), добавить методы доступа к полям. 
 * Класс Cow инкапсулирует поле «количество молока в день», добавить метод доступа 
 * к полям. В случае некорректных данных методы и конструкторы должны порождать 
 * исключения. В каждом классе переопределить методы AnimalSound() и AnimalInfo() 
 * в соответствии с типом животного. В консольном приложениии на основе данных, 
 * полученных от пользователя породить объект класса Dog и Cow, вывести информацию 
 * и звуки животных. В программе предусмотреть защиту от исключений. ​ 
 * 
 * Формат входных данных : 
 * -------test_1-------
 * Rex
 * 3
 * hunter
 * true
 * Murka
 * 8
 * 10
 * -------test_2-------
 * Rex
 * -3
 * hunter
 * true
 * Murka
 * 8
 * 10
 * --------------------
 * 
 * Формат выходных данных : 
 * -------test_1-------
 * Woof-woof!
 * Name: Rex
 * Age: 3
 * Breed: hunter
 * Trained: True
 * Moo-moo!
 * Name: Murka
 * Age: 8
 * Milk per day: 10
 * -------test_2-------
 * Incorrect input!
 * --------------------
 */

using System;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            //самостоятельно оберните нужный блок(и) в try-catch
            //в catch выводите на экран "Incorrect input!"
            Dog dog;
            Cow cow;

            string dogName = Console.ReadLine();
            int dogAge = IntInput();
            string breed = Console.ReadLine();
            bool isTrained = BoolInput();

            string cowName = Console.ReadLine();
            int cowAge = IntInput();
            int milkQuantity = IntInput();

            dog = new Dog(dogName, dogAge, breed, isTrained);
            dog.AnimalSound();
            Console.WriteLine(dog.AnimalInfo());

            cow = new Cow(cowName, cowAge, milkQuantity);
            cow.AnimalSound();
            Console.WriteLine(cow.AnimalInfo());
        }

        static bool BoolInput()
        {
            //обработать строковый ввод пользователя ("true"/"false")
        }

        static int IntInput()
        {
            //обработать ввод integer, в случае, если пользователь ввел не 
            //int выбросить Exception (обрабатывать не нужно).
        }
    }

    public abstract class Animal
    {
        private string name;
        private int age;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                //выбросьте исключение, если введена пустая строка
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                //выбросьте исключение, если введена пустая строка
                age = value;
            }
        }

        public abstract void AnimalSound();

        public abstract string AnimalInfo();
    }

    public class Dog : Animal
    {
        private string breed;
        private bool isTrained;

        public Dog(string name, int age, string breed, bool isTrained)
        {
            //реализуйте конструктор
        }

        public string Breed
        {
            get
            {
                return breed;
            }
            private set
            {
                //выбросьте исключение, если введена пустая строка
                breed = value;
            }
        }

        public bool IsTrained
        {
            get
            {
                return isTrained;
            }
            private set
            {
                isTrained = value;
            }
        }
        public override string AnimalInfo()
        {
            return ToString();
        }

        public override void AnimalSound()
        {
            Console.WriteLine("Woof-woof!");
        }

        public override string ToString()
        {
            return $"Name: {Name}{Environment.NewLine}" +
                   $"Age: {Age}{Environment.NewLine}" +
                   $"Breed: {Breed}{Environment.NewLine}" +
                   $"Trained: {IsTrained}{Environment.NewLine}";
        }
    }

    public class Cow : Animal
    {
        private int milkQuantity;

        public Cow(string name, int age, int milkQuantity)
        {
            //реализуйте конструктор
        }

        public int MilkQuantity 
        {
            get => milkQuantity; 
            set
            {
                if (value < 0)
                {
                    throw new Exception();
                }
                milkQuantity = value;
            }
        }

        public override string AnimalInfo()
        {
            return ToString();
        }

        public override void AnimalSound()
        {
            Console.WriteLine("Moo-moo!");
        }

        public override string ToString()
        {
            return $"Name: {Name}{Environment.NewLine}" +
                   $"Age: {Age}{Environment.NewLine}" +
                   $"Milk per day: {MilkQuantity}{Environment.NewLine}";
        }
    }
}
