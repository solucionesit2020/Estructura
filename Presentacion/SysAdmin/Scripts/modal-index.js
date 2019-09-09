(function ($) {
    function ModalView()
    {
        var $this = this;
        function initilizeModel() {
            $("#modal-action-estudiante").on('loaded.bs.modal', function (e) {
                console.log('text1');
            }).on('hidden.bs.modal', function (e) {
                $(this).removeData('bs.modal');
            });
        }
        $this.init = function () {
            initilizeModel();
        }
    }

    $(function () {
        var self = new ModalView();
        self.init();
    })
}(jQuery))
