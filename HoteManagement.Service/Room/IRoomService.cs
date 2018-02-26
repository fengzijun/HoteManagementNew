using HoteManagement.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteManagement.Service.Room
{
    public interface IRoomService
    {
        List<room_typeDto> GetRoomTypeList();


        room_typeDto GetRoomTypeById(int id);


        List<hourse_schemeDto> Gethourse_schemeList();


        hourse_schemeDto Gethourse_schemeById();


        List<room_numberDto> GetRoomNumberList(int roomtype, int statue);


        List<book_roomDto> GetBookRoomList(DateTime time, int[] stateid);


        int GetBookRoomCount();


        List<Book_RdetailDto> GetBookRetails(string bookno);



        guest_sourceDto GetGuest_Source(int id);

        void UpdateBookRoom(book_roomDto book_Room);


        List<BookStateDto> GetBookStateList();

        BookStateDto GetBookState(int id);


        IPagedList<book_roomDto> GetBookRoomList(string bookname, DateTime? starttime, DateTime? endtime, string bookno, string teleno, int[] stateid, int pageindex, int pagesize);

        List<card_typeDto> GetAllCardTypeList();



        List<real_modeDto> GetAllRealModelList();


        real_modeDto GetRealModelById(int id);

        void Addoccu_infor(occu_inforDto model);


        List<occu_inforDto> GetOccu_inforList(string orderid, string roomnumber, int? stateid);


        occu_inforDto Getoccu_inforById(int id);


        void Updateoccu_infor(occu_inforDto model);


        List<goods_accountDto> GetgoodsaccountList(string bookno, string ga_name, string account, string occno, string[] goodno, int? ga_Type);


        void UpdateGoods_account(goods_accountDto goods_Account);



        void AddGoods_account(goods_accountDto goods_Account);


        room_numberDto GetRoom_NumberById(int id);

        void DeleteFloorManage(int id);


        void DeleteRoomType(int id);


        void DeleteRoomNumber(int id);

        void AddRoomType(room_typeDto room_Type);


        void UpdateRoomType(room_typeDto room_Type);


        List<room_stateDto> GetRoomStateList();



        void Addroom_state(room_stateDto room_State);


        void Updateroom_state(room_stateDto room_State);


        void AddFset(FtSetDto ftSet);


        void UpdateFset(FtSetDto ftSet);


        void Addmodes(modesDto modes);


        void Updatemodes(modesDto modes);

        modesDto GetmodesById(int id);

        List<modesDto> GetmodesList();


        void Deletemodes(int id);

        IPagedList<room_numberDto> GetRoomNumberPageList(int pageindx, int pagesize);
      

    }
}
