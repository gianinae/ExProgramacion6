"use strict";
var TituloEdit;
(function (TituloEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(TituloEdit || (TituloEdit = {}));
//# sourceMappingURL=Edit.js.map