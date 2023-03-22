  var InputPlugin = {
    CreateInput: function() {
      var name = 'WebGLVRM'
      var fileInput = document.createElement('input');
      fileInput.setAttribute('type', 'file');
      fileInput.setAttribute('accept', '.vrm');
      fileInput.setAttribute('id', name);
      fileInput.onclick = function (event) {
        this.value = null;
      };
      fileInput.onchange = function (event) {
        SendMessage('WebGLVRM', 'FileSelected', URL.createObjectURL(event.target.files[0]));
      }
      document.body.appendChild(fileInput);
    },
    ClickInput: function() {
      var name = 'WebGLVRM'
      document.getElementById(name).click();
    }
  };
  mergeInto(LibraryManager.library, InputPlugin);