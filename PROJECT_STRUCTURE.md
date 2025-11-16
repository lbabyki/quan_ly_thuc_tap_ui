# 📂 Cấu trúc dự án chi tiết

## 🏗️ Kiến trúc 3-Layer

```
┌─────────────────────────────────────────────────────────┐
│                  PRESENTATION LAYER                      │
│              (MyWinFormsApp - UI)                        │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐  │
│  │  LoginForm   │  │ StudentForm  │  │  AdminForm   │  │
│  └──────────────┘  └──────────────┘  └──────────────┘  │
└─────────────────────────────────────────────────────────┘
                          ↓ ↑
┌─────────────────────────────────────────────────────────┐
│                 BUSINESS LOGIC LAYER                     │
│            (MyWinFormsApp.Business)                      │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐  │
│  │ UserService  │  │StudentService│  │ AdminService │  │
│  └──────────────┘  └──────────────┘  └──────────────┘  │
│  ┌──────────────────────────────────────────────────┐  │
│  │  Models: User, Student, Company, Lecturer, etc.  │  │
│  └──────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────┘
                          ↓ ↑
┌─────────────────────────────────────────────────────────┐
│                  DATA ACCESS LAYER                       │
│           (MyWinFormsApp.DataAccess)                     │
│  ┌──────────────────────────────────────────────────┐  │
│  │              ApiClient (JWT Token)                │  │
│  └──────────────────────────────────────────────────┘  │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐  │
│  │UserRepository│  │StudentRepo   │  │ AdminRepo    │  │
│  └──────────────┘  └──────────────┘  └──────────────┘  │
└─────────────────────────────────────────────────────────┘
                          ↓ ↑
                    ┌─────────────┐
                    │  REST API   │
                    │  (Backend)  │
                    └─────────────┘
```

## 📁 Chi tiết từng Layer

### 1️⃣ MyWinFormsApp (Presentation Layer)

**Mục đích**: Hiển thị giao diện người dùng, xử lý input/output

```
MyWinFormsApp/
├── Forms/
│   ├── LoginForm.cs              # Form đăng nhập
│   └── LoginForm.Designer.cs     # UI Designer code
├── Controls/                     # Custom controls (nếu có)
├── Program.cs                    # Entry point
└── MyWinFormsApp.csproj
```

**Trách nhiệm**:
- Hiển thị UI
- Validate input cơ bản
- Gọi Business Layer
- Hiển thị kết quả cho user

**Dependencies**:
- MyWinFormsApp.Business
- MyWinFormsApp.MockData (cho testing)

---

### 2️⃣ MyWinFormsApp.Business (Business Logic Layer)

**Mục đích**: Xử lý logic nghiệp vụ, validation phức tạp

```
MyWinFormsApp.Business/
├── Services/
│   └── UserService.cs            # Business logic cho User
├── Models/
│   ├── User.cs                   # Domain model
│   ├── Student.cs
│   ├── Company.cs
│   ├── Lecturer.cs
│   └── Internship.cs
└── MyWinFormsApp.Business.csproj
```

**Trách nhiệm**:
- Business rules và validation
- Xử lý logic nghiệp vụ
- Map giữa DTO và Domain Models
- Orchestrate các Repository calls

**Dependencies**:
- MyWinFormsApp.DataAccess

---

### 3️⃣ MyWinFormsApp.DataAccess (Data Access Layer)

**Mục đích**: Giao tiếp với API backend, quản lý data

```
MyWinFormsApp.DataAccess/
├── ApiClient.cs                  # Quản lý API connection, JWT
├── Repositories/
│   └── UserRepository.cs         # API calls cho User
├── Models/
│   ├── ApiResponse.cs            # DTO cho response
│   ├── LoginRequest.cs           # DTO cho request
│   └── LoginResponse.cs
└── MyWinFormsApp.DataAccess.csproj
```

**Trách nhiệm**:
- Gọi REST API
- Quản lý JWT Token
- Serialize/Deserialize JSON
- Error handling cho API calls

**Dependencies**:
- RestSharp (112.1.0)
- Newtonsoft.Json (13.0.4)

---

### 4️⃣ MyWinFormsApp.MockData (Mock Data Layer)

**Mục đích**: Cung cấp dữ liệu giả lập cho testing

```
MyWinFormsApp.MockData/
├── UserMockData.cs               # Mock data cho User
└── MyWinFormsApp.MockData.csproj
```

**Trách nhiệm**:
- Cung cấp test data
- Simulate API responses
- Hỗ trợ development không cần backend

**Dependencies**:
- MyWinFormsApp.Business

---

## 🔄 Data Flow

### Login Flow Example

```
1. User nhập email/password vào LoginForm
   ↓
2. LoginForm gọi UserService.LoginAsync()
   ↓
3. UserService validate input
   ↓
4. UserService gọi UserRepository.LoginAsync()
   ↓
5. UserRepository tạo RestRequest qua ApiClient
   ↓
6. ApiClient gửi POST request đến /v1/api/auth/login
   ↓
7. API trả về response (token + user info)
   ↓
8. UserRepository parse JSON response
   ↓
9. UserRepository lưu JWT token vào ApiClient
   ↓
10. UserRepository trả về LoginResponse DTO
    ↓
11. UserService map DTO → Domain Model (User)
    ↓
12. UserService trả về (success, message, user)
    ↓
13. LoginForm hiển thị kết quả cho user
```

## 🎯 Design Patterns

### 1. Repository Pattern
- Tách biệt logic truy cập dữ liệu
- Dễ dàng thay đổi data source (API → Database)
- Example: `UserRepository`, `StudentRepository`

### 2. Service Pattern
- Tập trung business logic
- Reusable across multiple UI components
- Example: `UserService`, `StudentService`

### 3. DTO Pattern
- Transfer data giữa layers
- Tách biệt API models và Domain models
- Example: `LoginRequest`, `LoginResponse`, `ApiResponse<T>`

### 4. Singleton Pattern (Static)
- ApiClient quản lý JWT token globally
- Đảm bảo token consistency

## 📦 Dependencies Graph

```
MyWinFormsApp
    ↓ references
MyWinFormsApp.Business
    ↓ references
MyWinFormsApp.DataAccess
    ↓ uses
RestSharp + Newtonsoft.Json

MyWinFormsApp
    ↓ references (for testing)
MyWinFormsApp.MockData
    ↓ references
MyWinFormsApp.Business
```

## 🔐 Security Considerations

1. **JWT Token**: Lưu trong memory (ApiClient.JwtToken)
2. **Password**: Không log, không lưu plain text
3. **HTTPS**: Nên dùng HTTPS trong production
4. **Token Expiry**: Cần implement refresh token logic

## 🧪 Testing Strategy

1. **Mock Data**: Test UI mà không cần backend
2. **Unit Tests**: Test từng Service/Repository riêng lẻ
3. **Integration Tests**: Test toàn bộ flow
4. **UI Tests**: Test user interactions

## 📝 Naming Conventions

- **Forms**: `{Feature}Form.cs` (LoginForm, StudentForm)
- **Services**: `{Entity}Service.cs` (UserService, StudentService)
- **Repositories**: `{Entity}Repository.cs` (UserRepository)
- **Models**: `{Entity}.cs` (User, Student)
- **DTOs**: `{Purpose}Request/Response.cs` (LoginRequest)

## 🚀 Extensibility

Để thêm chức năng mới:

1. Tạo Model trong Business/Models
2. Tạo Repository trong DataAccess/Repositories
3. Tạo Service trong Business/Services
4. Tạo Form trong UI/Forms
5. Tạo MockData nếu cần test

---

**Cấu trúc này đảm bảo**:
- ✅ Separation of Concerns
- ✅ Maintainability
- ✅ Testability
- ✅ Scalability
- ✅ Reusability

