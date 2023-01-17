using AcademyConsole;

//using MathLib mathLib = GenericMath();
//mathLib.Show();

using SqlDbConnection sqlConnection =ConnectionDB();
sqlConnection.Show();
MathLib GenericMath()
{
    using MathLib mathlib = new MathLib();
    return mathlib;
}

SqlDbConnection ConnectionDB()
{
    using SqlDbConnection sqlConnection2 = new SqlDbConnection(" dilara");
    Console.WriteLine("State: " + sqlConnection2.Connection.State);
    return sqlConnection2;
}
