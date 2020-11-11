using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelCrm.Models;
using ModelCrm.Options;
using ModelCrm.Services;

namespace CrmWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ICustomerCrude customerService = new CustomerCrud();


        [HttpGet("customers")]
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = customerService.GetAllCustomers();
            return customers;
        }

        [HttpGet("customers/{id}")]
        public  Customer  GetOneCustomers(int id)
        {
            Customer customer = customerService.GetCustomerById(id);
            return customer;
        }

        [HttpPost("customers")]
        public Customer AddCustomer(CustomerOptions customerOpt)
        { 
         return   customerService.CreateCustomer(customerOpt);
        }

        [HttpPut("customers/{id}")]
        public Customer UpdateCustomer(CustomerOptions customerOpt, int id)
        {
             return customerService.UpdateCustomer(customerOpt, id);
        }

        [HttpDelete("customers/{id}")]
        public bool DeleteCustomer( int id)
        {
             return customerService.DeleteCustomer(id);
        }


    }
}
