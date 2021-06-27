using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;
using Entity.dbo;

namespace WebApplicationCore.Pages.Puestos
{
    public class GridPuestosModel : PageModel
    {
        private readonly IPuestoService puestoService;

        public GridPuestosModel(IPuestoService puestoService)
        {
            this.puestoService = puestoService;
        }
        public IEnumerable<PuestosEntity> GridList { get; set; } = new List<PuestosEntity>();
        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await puestoService.Get();

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
                var result = await puestoService.Delete(new()
                {
                    Id_Puesto = id
                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }
                TempData["Msg"] = "Se elimino correctamente";

                return Redirect("GridPuestos");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
