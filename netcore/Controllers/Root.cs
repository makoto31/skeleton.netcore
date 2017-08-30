using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skeleton.Data;
using Skeleton.Models;
using Skeleton.ViewModels;

namespace Skeleton.Controllers{

    [Route("")]
    public class Root : Controller{

        private readonly SkeletonContext mContext;
        private readonly ILogger<Root> mLog;

        public Root(SkeletonContext context, ILogger<Root> log){
            mContext = context;
            mLog = log;
        }

        [HttpGet]
        public IActionResult Index(){
            return View();
        }

        [HttpPost]
        [Route("addPerson")]
        public async Task<PersonData> addPerson(PersonData vm){
            var person = new Person();
            person.FirstMidName = vm.FirstName;
            person.LastName = vm.LastName;
            mContext.Add(person);
            await mContext.SaveChangesAsync();
            return vm;
        }

        [HttpPost]
        [Route("persons")]
        public async Task<List<Person>> Persons(){

            var people = await mContext.People.ToListAsync();
            return people;
        }
    }
}