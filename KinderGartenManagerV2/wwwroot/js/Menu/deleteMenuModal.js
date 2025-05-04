const deleteModal = document.getElementById('deleteMenuModal');
deleteModal.addEventListener('show.bs.modal', function (event) {
    const button = event.relatedTarget;
    const id = button.getAttribute('data-id');

    document.getElementById('deleteMenuId').value = id;
});