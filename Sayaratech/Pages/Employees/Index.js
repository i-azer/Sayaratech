$(function () {
    var l = abp.localization.getResource('Sayaratech');
    var createModal = new abp.ModalManager(abp.appPath + 'Employees/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Employees/EditModal');
    var uploadModal = new abp.ModalManager(abp.appPath + 'Employees/FileModal');

    var dataTable = $('#EmployeesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(sayaratech.services.employees.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('Sayaratech.Employees.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Upload'),
                                    visible: abp.auth.isGranted('Sayaratech.Employees.Edit'),
                                    action: function (data) {
                                        uploadModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('Sayaratech.Employees.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'EmployeeDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        sayaratech.services.employees
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('EmailAddress'),
                    data: "emailAddress"
                },
                {
                    title: l('Phone'),
                    data: "phone"
                },
                {
                    title: l('Department'),
                    data: "departmentName"
                },
                {
                    title: l('IsStillWorking'),
                    data: "isStillWorking"
                },
                {
                    title: l('File'),
                    render: function (nTd, sData, oData, iRow) {
                        console.log("odata", oData)
                        if (oData.hasPhysicalFile) {
                            return "<a href='https://localhost:44368/download/" + oData.id + "'" + "target = '_blank'" + "'>" + oData.name + "</a>"

                        } else {
                            return "Not Yet Uploaded"
                        }
                    }
         
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
    uploadModal.onResult(function () {
        abp.notify.info(
            l('SuccessfullyUploaded')
        );
        dataTable.ajax.reload();
    });

    $("#UploadFileDto_File").change(function () {
        e.preventDefault();
    });

    $('#NewEmployeeButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});