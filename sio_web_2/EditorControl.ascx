<%@ Control Language="vb" AutoEventWireup="true" CodeBehind="EditorControl.ascx.vb" Inherits="sio_web_2.EditorControl" %>


<html lang="en">
<head>
    <meta charset="utf-8">
    <title>CKEditor 5 – Classic editor</title>
  <%--  <script src="https://cdn.ckeditor.com/ckeditor5/23.1.0/classic/ckeditor.js"></script>--%>
    <script src="https://cdn.ckeditor.com/ckeditor5/23.1.0/decoupled-document/ckeditor.js"></script>
</head>
<body>
  <%--  <h1>Classic editor</h1>
    <div id="editor">
        <p>This is some sample content.</p>
    </div>
    <script>
        ClassicEditor
            .create(document.querySelector('#editor') )
            .catch( error => {
                console.error( error );
            });



       


    </script>--%>



      <h1>Document editor</h1>

    <!-- The toolbar will be rendered in this container. -->
    <div id="toolbar-container"></div>

    <!-- This container will become the editable. -->
    <div id="editor2">
        <p>This is the initial editor content.</p>
    </div>

    <script>
        DecoupledEditor
            .create(document.querySelector('#editor2'))
            .then(editor => {
                const toolbarContainer = document.querySelector('#toolbar-container');

                toolbarContainer.appendChild(editor.ui.view.toolbar.element);
            })
            .catch(error => {
                console.error(error);
            });
    </script>
</body>
</html>