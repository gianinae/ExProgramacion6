using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;
using Entity.dbo;

namespace WebApplicationCore.Pages.Titulo
{
    public class EditModel : PageModel
    {
        private readonly ITituloService tituloService;

        public EditModel(ITituloService tituloService)
        {
            this.tituloService = tituloService;
        }
        [BindProperty]
        public TituloEntity Entity { get; set; } = new TituloEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {
                    Entity = await tituloService.GetById(new() { Id_Titulo = id });
                }

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                if (Entity.Id_Titulo.HasValue)
                {
                    //Actualizar 
                    var result = await tituloService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se actualizó correctamente";
                }
                else
                {
                    //Nuevo 
                    var result = await tituloService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "Se agregó correctamente";

                }

                return RedirectToPage("GridTitulo");
            }

            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

    }
}
