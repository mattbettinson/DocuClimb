using AutoMapper;
using DocuClimb.Data;
using DocuClimb.Data.Repositories;
using DocuClimb.Domain;
using DocuClimb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocuClimb.Web.Controllers
{
    public class ClimbController : Controller
    {
        //
        // GET: /Climb/List

        public ActionResult List()
        {
            var climbs = _repository.FindAll().ToList<Climb>();

            var mappedClimbs = new List<DocuClimb.Web.Models.Climb>();

            foreach (var dataClimb in climbs)
            {
                mappedClimbs.Add(Mapper.Map<DocuClimb.Domain.Climb, DocuClimb.Web.Models.Climb>(dataClimb));
            }

            return View(mappedClimbs);
        }

        private IRepository<Climb> _repository = new ClimbRepository(new DocuClimbDbContext());

    }
}
