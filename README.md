ykPermission
============

前言：
<br/>一直以来，权限系统都是应用系统不可缺少的部分,若每个应用系统都重新对系统的权限进行设计,以满足不同系统用户的需求,将会浪费不少宝贵时间,所以设计一个相对通用的权限系统是很有意义跟必要的.

项目结构：<br/>
YK.BusinessLogicLayer--业务逻辑层<br/>
--YK.BLL<br/>
--YK.IBLL<br>
YK.DataAccessLayer--数据访问层<br/>
--YK.DAL<br/>
--YK.IDAL<br/>
YK.Domain--域，主要是实体<br/>
--YK.Model<br/>
YK.Infrastructure--公共设施(公用类)<br/>
--YK.Common<br/>
--YK.CacheStorage<br/>
YK.UserInterface--用户界面
--ykPermissionWebUI
