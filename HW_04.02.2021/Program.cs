using System;
using System.Data.SqlClient;
namespace homwork
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Data source=DESKTOP-DV4MO7V\SQLEXPRESS; Initial catalog=AlifAcademy; Integrated Security = True";
            SqlConnection con = new SqlConnection(connectionString);

            int info;


            Console.WriteLine("Insert -> 1 \n" +
                "Delete -> 2 \n" +
                "Select All ->3 \n" +
                "Select by Id - > 4 \n" +
                "Exit ->0");
            Console.Write("выбирите команду!!! = ");

            info = Convert.ToInt32(Console.ReadLine());

            while (info != 0)
            {
                switch (info)
                {
                    case 1:
                        {
                            Console.Write("FirstName: "); string FirstName = Console.ReadLine();
                            Console.Write("LastName: "); string LastName = Console.ReadLine();
                            Console.Write("MiddleName: "); string MiddleName = Console.ReadLine();
                            Console.Write("BirthDate : ");
                            string BirthDate = Console.ReadLine();


                            string Insert = $"INSERT INTO Person ([FirstName]," +
                                $"[LastName], " +
                                $"[MiddleName], " +
                                $"[BirthDate])" +
                                $" VALUES ( '{FirstName}', '{LastName}', '{MiddleName}' , '{BirthDate}')";
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(Insert, connection);
                                int result = command.ExecuteNonQuery();
                                Console.WriteLine($"Добавлено : {result}");
                                Console.Write("выбирите команду!!! = ");
                                Console.WriteLine("Insert -> 1 \n" +
                                    "Delete -> 2 \n" +
                                    "Select All ->3 \n" +
                                    "Select by Id - > 4 \n" +
                                    "Exit ->0");
                                info = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        break;

                    case 2:
                        Console.Write("id = ");
                        int i = Convert.ToInt32(Console.ReadLine());
                        string Dalete = $"DELETE  FROM Person WHERE Id ='{i}'";
                        using (SqlConnection connectionDalete = new SqlConnection(connectionString))
                        {
                            connectionDalete.Open();
                            SqlCommand command3 = new SqlCommand(Dalete, connectionDalete);
                            int result1 = command3.ExecuteNonQuery();
                            Console.WriteLine("Удалено объектов: {0}", result1);
                            Console.Write("выбирите команду!!! = ");
                            Console.WriteLine("Insert -> 1 \n" +
                                "Delete-> 2 \n" +
                                "Select All -> 3 \n" +
                                "Select by Id ->4 \n" +
                                "Exit ->0");


                            info = Convert.ToInt32(Console.ReadLine());
                        }
                        break;

                    case 3:
                        string Select = "SELECT * FROM Person";
                        using (SqlConnection connectionSelect = new SqlConnection(connectionString))
                        {
                            connectionSelect.Open();
                            SqlCommand commandselect = new SqlCommand(Select, connectionSelect);
                            SqlDataReader reader = commandselect.ExecuteReader();
                            while (reader.Read())
                                Console.WriteLine($"ID: {reader.GetValue(0)}, " +
                                    $"Firstname:{reader.GetValue(1)} | " +
                                    $"LastName:{reader.GetValue(2)} |" +
                                    $" MiddleName:{reader.GetValue(3)} |" +
                                    $" BirthDate:{reader.GetValue(4)}");

                            Console.Write("выбирите команду!!! = ");

                            Console.WriteLine("Insert -> 1 \n" +
                                "Delete -> 2 \n" +
                                "Select All  ->3 \n" +
                                "Select by Id - > 4 \n" +
                                "Exit ->0");
                            info = Convert.ToInt32(Console.ReadLine());
                        }
                        break;


                    case 4:

                        Console.Write("id = ");
                        int iD = Convert.ToInt32(Console.ReadLine());
                        string connectionId = $"Select * from Person where Person.Id = {iD}";

                        using (SqlConnection connectionid = new SqlConnection(connectionString))
                        {
                            connectionid.Open();
                            SqlCommand commandselect = new SqlCommand(connectionId, connectionid);

                            {



                                var readerid = commandselect.ExecuteReader();
                                while (readerid.Read())
                                {

                                    Console.WriteLine($"Id: {readerid["Id"]}," +
                                        $"Name: {readerid["FirstName"]}, " +
                                        $"Surame: {readerid["LastName"]}," +
                                        $"FatherName: {readerid["MiddleName"]}," +
                                        $"BirthDate{readerid["BirthDate"]}");
                                    Console.Write("Select a command = ");
                                    Console.WriteLine("Insert -> 1 \n" +
                                        "Delete  -> 2 \n" +
                                        "Select All ->3 \n" +
                                        "Select by Id  - > 4 \n" +
                                        "Exit ->0");
                                    info = Convert.ToInt32(Console.ReadLine());
                                }

                            }
                            break;









                        }


                }
            }
        }
    }
}

