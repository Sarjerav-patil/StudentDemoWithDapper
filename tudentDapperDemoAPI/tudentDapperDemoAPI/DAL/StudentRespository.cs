using Dapper;
using Microsoft.IdentityModel.Protocols;
using StudentDapperDemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using static tudentDapperDemoAPI.Startup;
using Microsoft.EntityFrameworkCore;

namespace StudentDapperDemoAPI.DAL
{
    public partial class StudentRespository: IStudentRepository
    {

        private readonly StudentDbContext context;
        public StudentRespository(StudentDbContext dbContext)
        {
            context = dbContext;
        }

        //private readonly IConfiguration configuration;

        
        //private readonly IDbConnection _db;

        //SqlConnection conn = new SqlConnection(new DBConn().ConnectionString());
        
        //public string query = null;

      //  public StudentRespository()
        //{
            
        //_db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //    //_db = new SqlConnection(new DBConn().ConnectionString());
        //}
        public List<Student> GetStudents(int amount, string sort)
        {
            //throw new NotImplementedException();

            //return this._db.Query<Student>("SELECT TOP " + amount + " [StudId],[StudName],[StudAddress],[StudGender],[StudClass],[StudFatherName],[StudMotherName] FROM [StudentInfo] ORDER BY StudId " + sort).ToList();
            return context.Students.ToList();
        }

        public Student GetSingleStudent(int StudId)
        {
            return context.Students.Find(StudId);
            // return _db.Query<Student>("SELECT[StudId],[StudName],[StudAddress],[StudGender],[StudClass],[StudFatherName],[StudMotherName] FROM [StudentInfo] WHERE StudId =@StudId", new { StudId = StudId }).SingleOrDefault();
        }

        public void InsertStudent(Student ourStudent)
        {
            context.Students.Add(ourStudent);
            //int rowsAffected = this._db.Execute(@"INSERT StudentInfo([StudName],[StudAddress],[StudGender],[StudClass],[StudFatherName],[StudMotherName]) values (@StudName, @StudAddress, @StudGender,@StudClass,@StudFatherName,@StudMotherName)", new { StudName = ourStudent.StudName, StudAddress = ourStudent.StudAddress, StudGender = ourStudent.StudGender, StudClass = ourStudent.StudClass, StudFatherName = ourStudent.StudFatherName, StudMotherName = ourStudent.StudMotherName });

            //if (rowsAffected != 0)
            //{
            //    return true;
            //}
            //return false;
        }

        public void DeleteStudent(int StudId)
        {
            Student student = context.Students.Find(StudId);
            context.Students.Remove(student);
            //int rowsAffected = this._db.Execute(@"DELETE FROM [StudentInfo] WHERE StudId = @StudId", new { StudId = StudId });

            //if (rowsAffected > 0)
            //{
            //    return true;
            //}
            //return false;
        }

        public void UpdateStudent(Student ourStudent)
        {
            context.Entry(ourStudent).State = EntityState.Modified;
            //    int rowsAffected = this._db.Execute("UPDATE [StudentInfo] SET [StudName] = @StudName ,[StudAddress] = @StudAddress, [StudGender] = @StudGender,[StudClass]=@StudClass,[StudFatherName]=@StudFatherName,[StudMotherName]=@StudMotherName WHERE StudId = " + ourStudent.StudId, ourStudent);

            //    if (rowsAffected != 0)
            //    {
            //        return true;
            //    }
            //    return false;
        }

        public void Save()
        {
            context.SaveChanges();
        }


    }

}