const editModal = document.getElementById('editMenuModal');
if (editModal) {
    editModal.addEventListener('show.bs.modal', function (event) {
        const button = event.relatedTarget;
        const id = button.getAttribute('data-id');
        const countChild = button.getAttribute('data-countchild');
        const typeChild = button.getAttribute('data-typechild');

        document.getElementById('editMenuId').value = id;
        document.getElementById('editCountChild').value = countChild;
        document.getElementById('editTypeChild').value = typeChild;
    });
}