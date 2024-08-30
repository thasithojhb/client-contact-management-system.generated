using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using client_contact_management_system.Models;
using client_contact_management_system.Models.Interfaces;

namespace client_contact_management_system.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IRepository _repository;

    public HomeController(ILogger<HomeController> logger, IRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ClientTab()
    {    
       return PartialView("_ClientTab", model: _repository.GetAllClients());
    }

    [HttpPost]
    public IActionResult CreateClient(ClientViewModel client)
    {
        _repository.AddClient(client);

        return Json(_repository.GetAllClients());
    }

    public IActionResult ContactsTab()
    {
        
        //var ClientViewModelList = new List<ClientViewModel>
        //{
        //    new ClientViewModel { Name = "Sample Client", ClientCode = "C001", Contacts = 1 },
        //    new ClientViewModel { Name = "Sample Client", ClientCode = "C002", Contacts = 49 }
        //};
        //var model = new List<ContactViewModel>
        //{
        //    new ContactViewModel { Name = "John", Surname = "Doe", Email = "john.doe@example.com", Clients = 9 },
        //    new ContactViewModel { Name = "Jane", Surname = "Smith", Email = "jane.smith@example.com", Clients = 0 },
        //};
        return PartialView("_ContactsTab", model: _repository.GetAllContacts());
    }
    
    [HttpPost]
    public IActionResult CreateContact(ContactViewModel Contact)
    {
        if (_repository.ContactExist(Contact.Email))
        {
            ModelState.AddModelError("Email", "This email address is already in use.");
            return BadRequest(ModelState);
        }
        _repository.AddContact(Contact);

        return Json(_repository.GetAllContacts());
    }

    public IActionResult LoadLinkContactModal()
    {
        return PartialView("_LinkContact", model: _repository.GetAllClientsAndContacts());
    }

    [HttpPost]
    public IActionResult LinkContact(Linked linkedClientAndContact)
    {
        //if (_repository.ContactLinked(Contact.Email))
        //{
        //    ModelState.AddModelError("Email", "This email address is already in use.");
        //    return BadRequest(ModelState);
        //}
        _repository.LinkContact(linkedClientAndContact);

        return Json(_repository.GetLinks());
    }


}
