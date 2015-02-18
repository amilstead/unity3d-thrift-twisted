include "core.thrift"

namespace csharp Services.User
namespace py _thrift.services.user

struct User {
  1: i32 user_id
  2: string username
  3: string password
}

service User extends core.SharedService {

   bool remove(1:i32 user_id),

   User create(1:string username, 2:string password),

   User get(1:string username),

   bool login(1:string username, 2:string password),

}
