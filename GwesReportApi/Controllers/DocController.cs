using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GwesReportApi.Inventory;
using GwesReportApi.Models;
using Microsoft.EntityFrameworkCore;
using GwesReportApi.Helpers;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace GwesReportApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocController : ControllerBase
    {
        private IConfiguration _config;
        private readonly GwesDbContext _context;
        public DocController(IConfiguration config, GwesDbContext context)
        {
            _config = config;

            _context = context;
        }
        
        [HttpPost]
        /*[Authorize]*/
        public List<DocModel> Doc()
        {
            var currentUser = HttpContext.User;
            var docs = _context
                     .DbDocs
                     .FromSqlRaw("exec AdvGetDoc")
                     .ToList();
            return docs;
        }

      
    }
}
