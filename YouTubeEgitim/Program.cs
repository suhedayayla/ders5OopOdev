namespace YouTubeEgitim
{
    class Program
    {
        static void Main(string[] args)
        {
            //değertipi
            //int sayi1 = 10;
            //int sayi2 = 20;
            //sayi1 = sayi2;
            //sayi2 = 100;
            //Console.WriteLine(sayi1); //sayi1 20 gelir.


            //
            //referans tipi
            //int[] sayilar1 = new[] { 1, 2, 3 };
            //int[] sayilar2 = new[] { 10, 20, 30 };
            //sayilar1 = sayilar2;
            //sayilar2[0] = 1000;
            //Console.WriteLine(sayilar1[0]); //1000 gelir

            //CreditManager creditManager = new CreditManager(); //eşitliğin sol tarafı belleğin stack tarafında
            // newlediğin anda belleğin heap tarafında referans oluşuyor.
            //creditManager.Calculate();
            //creditManager.Save();

            //Customer customer=new Customer(); //instance oluşturmak bunun adı. heapte referans nosu oluşturmak demek
            //customer.Id = 1;
            //customer.City = "Ankara";

            //CustomerManager customerManager = new CustomerManager(customer);
            //customerManager.Save();
            //customerManager.Delete();


            //Company company = new Company();
            //company.TaxNumber = "1122233";
            //company.CompanyName = "Arçelik";
            //company.Id = 100;

            //CustomerManager customerManager2 = new CustomerManager(new Person());


            //Person person = new Person();
            //person.FirstName = "Test";
            //person.LastName = "Test";
            //person.NationalIdentity = "123456";

            //Customer c1=new Customer();
            //Customer c2=new Person(); //c2nin yaptığı personın heapte oluşan ref numarasını tutabilmek
            //Customer c3=new Company();

            //Ioc Container.
            CustomerManager customerManager = new CustomerManager(new Customer(), new TeacherCreditManager());
            customerManager.GiveCredit();

            

            Console.ReadLine();
        }
    }
    class CreditManager //banka OPERASYON tutan class
    {
        public void Calculate()
        {
            Console.WriteLine("hesaplandı");

        }
        public void Save()
        {

            Console.WriteLine("kredi verildi");
        }


    }

        interface ICreditManager
    {
        void Calculate();
        void Save();

    }
     abstract class BaseCreditManager:ICreditManager  //bir sınıf sadece 1 sınıfı abstract edebilir. 
    {
        public abstract void Calculate(); //her yerde değişken. o yüzden böyle yazdık
        public virtual Save() //her yerde aynı. abstract sınıflar ortak operasyonları tutar.
        {
            Console.WriteLine(" kaydedildi");

        }



    }
    class TeacherCreditManager: BaseCreditManager, ICreditManager //teachercreditmanager classı icreditmanagerin metodlarını doldurmak zorundadır.
                                                                //interfaceler referans tiplerdir.
    {
        public override Calculate() //calculate operasyonum ortak değil override üstümne yazdık.
        {
            //hesaplamalar.
            Console.WriteLine("öğretmen kredisi hesaplandı");

        }
        public override void Save()
        {
            base.Save();
        }

    }
    class MilitaryCreditManager : BaseCreditManager, ICreditManager 
    {
        public override Calculate()
        {
            Console.WriteLine("asker kredisi hesaplandı");

        }
        

    }
    class CarCreditManager : BaseCreditManager, ICreditManager
    {
        public override Calculate() {
            Console.WriteLine("araba kredisi hesaplandı");

        }

    }

    class Customer //prop fonks. ÖZELLİK tutan class.
        {
        public Customer() //yukarıda customerı newlediğimiz yerde çalışacak kod bloğudur.
        {
            Console.WriteLine("Müşteri nesnesi başlatıldı.");
        }
        public int Id { get; set; }
        public string City { get; set; }

    }
        class Person:Customer{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }



    }
    class Company:Customer //company customer nesnesinden inheritance olur.
          {
        public string TaxNumber { get; set; }
        public string CompanyName { get; set; }

    }

    class CustomerManager
        {
              private Customer _customer; //private dedik sadece bu classta kullanocaz _customerı
              private ICreditManager _creditManager;

              public CustomerManager(Customer customer,ICreditManager creditManager) //constructor, icreditmanagerda interface ver diyorum
               {
                  _customer = customer;
                  _creditManager = creditManager;
               }
              public void Save()
                   {
                Console.WriteLine("Müşteri Kaydedildi");

                   }
              public void Delete()
                {
                Console.WriteLine("Müşteri Silindi");

               }
             public void GiveCredit() 
            { 
                 _creditManager.Calculate();
                 Console.WriteLine(" Kredi verildi");
        
             }
}


}