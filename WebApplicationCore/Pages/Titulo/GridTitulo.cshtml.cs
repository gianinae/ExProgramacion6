using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApplicationCore.Pages.Titulo
{
    public class GridTituloModel : PageModel
    {
        private readonly ITituloService tituloService;

        public GridTituloModel(ITituloService tituloService)
        {
            this.tituloService = tituloService;
        }
        public IEnumerable<TituloEntity> GridList { get; set; } = new List<TituloEntity>();
        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await tituloService.Get();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }
                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await tituloService.Delete(new()
                {
                    Id_Titulo = id
                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "Se elimino correctamente";

                return Redirect("GridTitulo");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}