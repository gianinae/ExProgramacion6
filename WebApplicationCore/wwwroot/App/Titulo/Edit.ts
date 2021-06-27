namespace TituloEdit {

    var Formulario = new Vue(
        {
            data:
            {
                Formulario: "#FormEdit"
            },
            mounted() {
                CreateValidator(this.Formulario);

            }
        }
    );

    Formulario.$mount("#AppEdit");


}