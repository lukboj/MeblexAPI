using Meblex.Features.Commands;
using Meblex.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Meblex.Controllers
{
    public class OpinionController : Controller
    {
        private readonly IMediator _mediator;

        public OpinionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetAllOpinionsQuery()));

        }

        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetOpinionByIdQuery() { id = id }));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOpinionCommand command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Nie można zapisać.");
            }
            return View(command);
        }

        [Authorize(Roles = "Administrator")]


        public async Task<IActionResult> Edit(int id)
        {
            return View(await _mediator.Send(new GetOpinionByIdQuery() { id = id }));
        }

        [Authorize(Roles = "Administrator")]


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateOpinionCommand command)
        {
   
            if (id != command.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(command);

            return RedirectToAction("index");

        }
        [Authorize(Roles = "Administrator")]

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteOpinionCommand() { Id = id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete. ");
            }

            return RedirectToAction(nameof(Index));
        }

       


    }
}
