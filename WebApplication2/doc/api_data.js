define({ "api": [
  {
    "type": "",
    "url": "(Post)",
    "title": "Thêm giáo viên vào lớp",
    "name": "AddTeacher",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id_GV",
            "description": "<p>ID của giáo viên</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id_Lop",
            "description": "<p>ID của lớp</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     \"Id_GV\" : \"1\",\n     \"Id_Lop\" : \"2\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id_GV",
            "description": "<p>ID của giáo viên vừa thêm</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id_Lop",
            "description": "<p>ID của lớp vừa được thêm giáo viên</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n{\n     \"Id_GV\" : \"1\",\n     \"Id_Lop\" : \"2\",\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NotFound",
            "description": "<p>{string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"Không tìm thấy giáo viên \",\n         \"Không xác định được lớp \"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class"
  },
  {
    "type": "",
    "url": "(Post)",
    "title": "Tạo một lớp mới",
    "name": "CreateTeacher",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Malop",
            "description": "<p>Mã của lớp mới</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Tenlop",
            "description": "<p>Tên của lớp mới</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     \"Malop\" : \"abc123\",\n     \"Tenlop\" : \"Công nghệ thông tin\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Malop",
            "description": "<p>Mã của lớp vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Tenlop",
            "description": "<p>Tên của lớp vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của lớp mới</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n{\n     \"Id\" : \"1\",\n     \"Malop\" : \"bcd123\",\n     \"Tenlop\" : \"Công nghệ thông tin 2\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "BadRequest",
            "description": "<p>{string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 400 Bad Request\n{\n     \"Errors\" : [\n         \"Mã lớp là trường bắt buộc\",\n         \"Tên lớp là trường bắt buộc\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class"
  },
  {
    "type": "",
    "url": "(Put)",
    "title": "Cập nhập thông tin lớp",
    "name": "EditTeacher",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của lớp cần cập nhập</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "MaLop",
            "description": "<p>Mã lớp mới</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Tenlop",
            "description": "<p>Tên lớp mới</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "GVCN_Id",
            "description": "<p>Id của giáo viên chủ nhiệm</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     \"Id\" : \"1\",\n     \"MaLop\" : \"15DTH\",\n     \"Tenlop\" : \"Công nghệ thông tin 2\",\n     \"GVCN_Id\" : 2\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>ID của lớp vừa cập nhập</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Malop",
            "description": "<p>Mã của lớp vừa cập nhập</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Tenlop",
            "description": "<p>Tên của lớp vừa cập nhập</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "GVCN_Id",
            "description": "<p>Id của giáo viên chủ nhiệm lớp này</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n{\n     \"Id\" : \"1\",\n     \"Malop\" : \"15DTH\",\n     \"Tenlop\" : \"Công nghệ thông tin 2\",\n     \"GVCN_Id\" : \"2\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NotFound",
            "description": "<p>{string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"Không tìm thấy lớp \"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class"
  },
  {
    "type": "",
    "url": "(Get)",
    "title": "Lấy danh sách lớp",
    "name": "GetAllClass",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>ID của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Malop",
            "description": "<p>Mã của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Tenlop",
            "description": "<p>Tên của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "GVCN_Id",
            "description": "<p>Id của giáo viên chủ nhiệm lớp</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n[\n     {\n         \"Id\" : \"1\",\n         \"Malop\" : \"15DTH\",\n         \"Tenlop\" : \"Công nghệ thông tin 2\",\n         \"GVCN_Id\" : \"2\"\n     },\n     {\n         \"Id\" : \"2\",\n         \"Malop\" : \"15DTH02\",\n         \"Tenlop\" : \"Kế toán\",\n         \"GVCN_Id\" : \"1\"\n     }\n]",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class"
  },
  {
    "type": "",
    "url": "(Get)",
    "title": "Tìm lớp theo ID",
    "name": "GetById",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>ID của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Malop",
            "description": "<p>Mã của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Tenlop",
            "description": "<p>Tên của lớp</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "GVCN_Id",
            "description": "<p>Id của giáo viên chủ nhiệm lớp</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "   HTTP/1.1 200 OK\n{\n    \"Id\" : \"1\",\n    \"Malop\" : \"15DTH\",\n    \"Tenlop\" : \"Công nghệ thông tin 2\",\n    \"GVCN_Id\" : \"2\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NotFound",
            "description": "<p>{string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"Không tìm thấy lớp \"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class"
  },
  {
    "type": "",
    "url": "(Get)",
    "title": "Lấy danh sách giáo viên dạy lớp",
    "name": "GetListTeacherById",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Teacher[]",
            "optional": false,
            "field": "DanhSachGiaoVien",
            "description": "<p>Danh sách giáo viên của lớp đó</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n{\n     \"DanhSachGiaoVien\": [\n         {\n             \"MaGV\": \"GV001\",\n             \"TenGV\": \"GiaoVien 01\",\n             \"Id\": 1\n         },\n         {\n             \"MaGV\": \"GV002\",\n             \"TenGV\": \"GiaoVien 02\",\n             \"Id\": 2\n         }\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NotFound",
            "description": "<p>{string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"Không tìm thấy lớp \"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class"
  },
  {
    "type": "",
    "url": "(Get)",
    "title": "Lấy danh sách sinh viên của lớp",
    "name": "GetListTeacherById",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "List",
            "optional": false,
            "field": "Danh",
            "description": "<p>sách sinh viên của lớp đó</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n{\n      \"DanhSachSinhVien\": [\n          {\n              \"HoTen\": \"anh khoi\",\n              \"NgaySinh\": \"1996-05-05T00:00:00\",\n              \"DiaChi\": \"15 To Ngoc Van\",\n              \"MSSV\": \"1511060526\",\n              \"Id\": 1,\n              \"LOP_ID\": 1\n          },\n          {\n              \"HoTen\": \"SV02\",\n              \"NgaySinh\": \"1996-05-05T00:00:00\",\n              \"DiaChi\": \"15 To Ngoc Van\",\n              \"MSSV\": \"151231\",\n              \"Id\": 2,\n              \"LOP_ID\": 1\n          }\n      ]\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NotFound",
            "description": "<p>{string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"Không tìm thấy lớp \"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class"
  },
  {
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": false,
            "field": "varname1",
            "description": "<p>No type.</p>"
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "varname2",
            "description": "<p>With type.</p>"
          }
        ]
      }
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "./doc/main.js",
    "group": "D__asp_trainning_asp01_WebApplication2_doc_main_js",
    "groupTitle": "D__asp_trainning_asp01_WebApplication2_doc_main_js",
    "name": ""
  },
  {
    "type": "",
    "url": "(Post)",
    "title": "Tạo một Sinh viên mới",
    "name": "CreateStudent",
    "group": "Student",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "MSSV",
            "description": "<p>Mã số sinh viên của Sinh viên</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "HoTen",
            "description": "<p>Họ và tên của Sinh viên</p>"
          },
          {
            "group": "Parameter",
            "type": "datetime",
            "optional": false,
            "field": "NgaySinh",
            "description": "<p>Ngày sinh của Sinh viên</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "DiaChi",
            "description": "<p>Địa chỉ của Sinh viên</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "LOP_ID",
            "description": "<p>ID của lớp Sinh viên học</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     \"MSSV\" : \"abc123\",\n     \"HoTen\" : \"ABC\",\n     \"NgaySinh\" : \"1997/2/15\",\n     \"DiaChi\" : \"23/asdas\",\n     \"LOP_ID\" : 1\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "MSSV",
            "description": "<p>Mã số sinh viên của Sinh viên</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "HoTen",
            "description": "<p>Họ và tên của Sinh viên</p>"
          },
          {
            "group": "Success 200",
            "type": "datetime",
            "optional": false,
            "field": "NgaySinh",
            "description": "<p>Ngày sinh của Sinh viên</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "DiaChi",
            "description": "<p>Địa chỉ của Sinh viên</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "LOP_ID",
            "description": "<p>ID của lớp Sinh viên học</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n {\n     \"MSSV\" : \"abc123\",\n     \"HoTen\" : \"ABC\",\n     \"NgaySinh\" : \"1997/2/15\",\n     \"DiaChi\" : \"23/asdas\",\n     \"LOP_ID\" : 1,\n     \"ID\" : 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "BadRequest",
            "description": "<p>{string} Errors Mảng các lỗi</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NotFound",
            "description": "<p>{string} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 400 Bad Request\n{\n     \"Errors\" : [\n         \"MSSV là trường bắt buộc\"\n     ]\n}",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"ID Lớp trống hoặc không tồn tại\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/StudentController.cs",
    "groupTitle": "Student"
  },
  {
    "type": "",
    "url": "(Put)",
    "title": "Cập nhập thông tin Sinh viên",
    "name": "EditStudent",
    "group": "Student",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "MSSV",
            "description": "<p>Mã số sinh viên (mới) của Sinh viên</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "HoTen",
            "description": "<p>Họ và tên (mới) của Sinh viên</p>"
          },
          {
            "group": "Parameter",
            "type": "datetime",
            "optional": false,
            "field": "NgaySinh",
            "description": "<p>Ngày sinh (mới) của Sinh viên</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "DiaChi",
            "description": "<p>Địa chỉ (mới) của Sinh viên</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "LOP_ID",
            "description": "<p>ID của lớp (mới) Sinh viên học</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "ID",
            "description": "<p>ID của Sinh viên cần sữa</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     \"MSSV\" : \"abc123\",\n     \"HoTen\" : \"ABC\",\n     \"NgaySinh\" : \"1997/2/15\",\n     \"DiaChi\" : \"23/asdas\",\n     \"LOP_ID\" : 1,\n     \"ID\" : 1\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "MSSV",
            "description": "<p>Mã số sinh viên (mới) của Sinh viên</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "HoTen",
            "description": "<p>Họ và tên (mới) của Sinh viên</p>"
          },
          {
            "group": "Success 200",
            "type": "datetime",
            "optional": false,
            "field": "NgaySinh",
            "description": "<p>Ngày sinh (mới) của Sinh viên</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "DiaChi",
            "description": "<p>Địa chỉ (mới) của Sinh viên</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "LOP_ID",
            "description": "<p>ID của lớp (mới) Sinh viên học</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n {\n     \"MSSV\" : \"abc123\",\n     \"HoTen\" : \"ABC\",\n     \"NgaySinh\" : \"1997/2/15\",\n     \"DiaChi\" : \"23/asdas\",\n     \"LOP_ID\" : 1,\n     \"ID\" : 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "BadRequest",
            "description": "<p>{string} Errors Mảng các lỗi</p>"
          },
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NotFound",
            "description": "<p>{string} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 400 Bad Request\n{\n     \"Errors\" : [\n         \"MSSV là trường bắt buộc\"\n     ]\n}",
          "type": "json"
        },
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"ID Sinh viên không tồn tại\",\n         \"ID Lớp trống hoặc không tồn tại\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/StudentController.cs",
    "groupTitle": "Student"
  },
  {
    "type": "",
    "url": "(Get)",
    "title": "Lấy danh sách Sinh viên",
    "name": "GetAllStudents",
    "group": "Student",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Student[]",
            "optional": false,
            "field": "Danh",
            "description": "<p>sách Sinh viên</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n[\n     {\n         \"MSSV\" : \"abc123\",\n         \"HoTen\" : \"ABC\",\n         \"NgaySinh\" : \"1997/2/15\",\n         \"DiaChi\" : \"23/asdas\",\n         \"LOP_ID\" : 1,\n         \"ID\" : 1\n     },\n     {\n         \"MSSV\" : \"abc126\",\n         \"HoTen\" : \"XYZ\",\n         \"NgaySinh\" : \"1997/6/15\",\n         \"DiaChi\" : \"213/asdas\",\n         \"LOP_ID\" : 1,\n         \"ID\" : 2\n     }\n]",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/StudentController.cs",
    "groupTitle": "Student"
  },
  {
    "type": "",
    "url": "(Get)",
    "title": "Tìm Sinh viên theo ID",
    "name": "GetStudentById",
    "group": "Student",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Th",
            "description": "<p>ông tin sinh viên</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n{\n     \"MSSV\" : \"abc123\",\n     \"HoTen\" : \"ABC\",\n     \"NgaySinh\" : \"1997/2/15\",\n     \"DiaChi\" : \"23/asdas\",\n     \"LOP_ID\" : 1,\n     \"ID\" : 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "NotFound",
            "description": "<p>{string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"Không tìm thấy sinh viên \"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/StudentController.cs",
    "groupTitle": "Student"
  },
  {
    "type": "",
    "url": "(Post)",
    "title": "Tạo một giáo viên mới",
    "name": "CreateTeacher",
    "group": "Teacher",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Malop",
            "description": "<p>Mã của lớp mới</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Tenlop",
            "description": "<p>Tên của lớp mới</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     \"Malop\" : \"abc123\",\n     \"Tenlop\" : \"Công nghệ thông tin\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Malop",
            "description": "<p>Mã của lớp vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Tenlop",
            "description": "<p>Tên của lớp vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của lớp mới</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n{\n     \"Id\" : \"1\",\n     \"Malop\" : \"bcd123\",\n     \"Tenlop\" : \"Công nghệ thông tin 2\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "BadRequest",
            "description": "<p>{string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 400 Bad Request\n{\n     \"Errors\" : [\n         \"Mã lớp là trường bắt buộc\",\n         \"Tên lớp là trường bắt buộc\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/TeacherController.cs",
    "groupTitle": "Teacher"
  },
  {
    "type": "",
    "url": "(Post)",
    "title": "Cập nhập thông tin Giáo Viên",
    "name": "EditTeacher",
    "group": "Teacher",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Malop",
            "description": "<p>Mã của lớp mới</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "Tenlop",
            "description": "<p>Tên của lớp mới</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     \"Malop\" : \"abc123\",\n     \"Tenlop\" : \"Công nghệ thông tin\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Malop",
            "description": "<p>Mã của lớp vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "Tenlop",
            "description": "<p>Tên của lớp vừa tạo</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id của lớp mới</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n{\n     \"Id\" : \"1\",\n     \"Malop\" : \"bcd123\",\n     \"Tenlop\" : \"Công nghệ thông tin 2\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "BadRequest",
            "description": "<p>{string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 400 Bad Request\n{\n     \"Errors\" : [\n         \"Mã lớp là trường bắt buộc\",\n         \"Tên lớp là trường bắt buộc\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/TeacherController.cs",
    "groupTitle": "Teacher"
  },
  {
    "type": "",
    "url": "(Get)",
    "title": "Lấy danh sách giáo viên",
    "name": "GetAllTeacher",
    "group": "Teacher",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Object[]",
            "optional": false,
            "field": "DanhSachGiaoVien",
            "description": "<p>Danh sách giáo viên</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n[\n  DanhSachGiaoVien\n\t{\n\t\n                \"MaGV\": \"GV001\",\n\t\n                \"TenGV\": \"GiaoVien 01\",\n\t\n                \"Id\": 1\n\t},\n\t{\n\t\n                \"MaGV\": \"GV002\",\n\t\n                \"TenGV\": \"GiaoVien 02\",\n\t        \"Id\": 2\n\t}\n]",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Not",
            "description": "<p>Found {string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"Không tìm thấy giáo viên này\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/TeacherController.cs",
    "groupTitle": "Teacher"
  },
  {
    "name": "GetListClass",
    "group": "Teacher",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Object[]",
            "optional": false,
            "field": "teacher",
            "description": "<p>Lấy danh sách lớp dạy theo ID giáo viên</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1 200 OK\n{    \n\n\t\"DanhSachLopDay\": [\n\t\t{\n  \t    \"MaLop\" : \"CNTT001\",\n\t        \"TenLop\": \"Công nghệ thông tin\",\n\t        \"Id\": 1\n\t\t},\n\t\t{\t\n\t        \"MaLop\": \"KT001\",\t\n\t        \"TenLop\": \"Kế toán\",\n    \t    \"Id\": 2\n\t\t}\n\t]\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Not",
            "description": "<p>Found {string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"Không tìm thấy giáo viên này\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "./Controllers/TeacherController.cs",
    "groupTitle": "Teacher"
  },
  {
    "name": "GetListClassCN",
    "group": "Teacher",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "Object[]",
            "optional": false,
            "field": "teacher",
            "description": "<p>Lấy danh sách lớp chủ nhiệm theo ID giáo viên</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1 200 OK\n{    \n\t\"DanhSachLopChuNhiem\" : [\n\t\t{\t\n\t        \"MaLop\" : \"CNTT001\",\t\n\t        \"TenLop\": \"Công nghệ thông tin\",\n\t        \"Id\": 1\n\t\t},\n\t\t{\t\n         \"MaLop\": \"KT001\",\n         \"TenLop\": \"Kế toán\",\n       \t\"Id\": 2\n\t\t}\n\t ]\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Not",
            "description": "<p>Found {string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"Không tìm thấy Giáo viên này\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "./Controllers/TeacherController.cs",
    "groupTitle": "Teacher"
  },
  {
    "type": "",
    "url": "(Get)",
    "title": "Lấy giáo viên theo ID",
    "name": "GetTeacherById",
    "group": "Teacher",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": false,
            "field": "teacher",
            "description": "<p>Danh sách giáo viên</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "    HTTP/1.1 200 OK\n\n{\n    \"MaGV\": \"GV001\",\n    \"TenGV\": \"GiaoVien 01\",\n    \"Id\": 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": false,
            "field": "Not",
            "description": "<p>Found {string[]} Errors Mảng các lỗi</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Error-Response:",
          "content": "    HTTP/1.1 404 Not Found\n{\n     \"Errors\" : [\n         \"Không tìm thấy giáo viên này\"\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/TeacherController.cs",
    "groupTitle": "Teacher"
  }
] });
