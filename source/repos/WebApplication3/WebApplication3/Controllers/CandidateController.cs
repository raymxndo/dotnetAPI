using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CandidateController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            string query = @"select candidate_id, first_name, last_name, email, phone_num, address_, country from dbo.Candidate";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CandidateAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon=new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]

        public JsonResult Post(Candidate can)
        {

            string query = @"insert into dbo.Candidate 
                           (first_name, last_name, email, phone_num, address_, country)
                           values ('"+can.first_name+ @"', '" + can.last_name + @"', '" + can.email + @"', '" + can.phone_num + @"', '" + can.address_ + @"',
                           '" + can.country + @"')";

            //string query = @"select candidate_id, first_name, last_name, email, phone_num, address_, country from dbo.Candidate";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CandidateAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully!");
        }

        [HttpPut]

        public JsonResult Put(Candidate can)
        {

            string query = @"update dbo.Candidate set
                           first_name = '" + can.first_name + @"',
                           last_name = '" + can.last_name + @"',
                           email = '" + can.email + @"',
                           phone_num = '" + can.phone_num + @"',
                           address_ = '" + can.address_ + @"',
                           country = '" + can.country + @"'
                           where candidate_id = " + can.candidate_id + @"";
            

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CandidateAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully!");
        }

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {

            string query = @"delete from dbo.Candidate where candidate_id = " + id + @"";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CandidateAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully!");
        }

    }
}
