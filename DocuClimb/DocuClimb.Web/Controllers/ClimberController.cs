using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocuClimb.Data.Repositories;
using DocuClimb.Interfaces;
using DocuClimb.Domain;
using DocuClimb.Data;
using AutoMapper;

namespace DocuClimb.Web.Controllers
{
    public class ClimberController : Controller
    {
  
        //
        // GET: /Climber/

        public ActionResult List()
        {
            var climbers = _repository.FindAll().ToList<Climber>();

            var mappedClimbers = new List<DocuClimb.Web.Models.Climber>();

            foreach (var dataClimber in climbers)
            {
                mappedClimbers.Add(Mapper.Map<DocuClimb.Domain.Climber, DocuClimb.Web.Models.Climber>(dataClimber));
            }
            
            return View(mappedClimbers);
        }

        private IRepository<Climber> _repository = new ClimberRepository(new DocuClimbDbContext());
        
    }
}
