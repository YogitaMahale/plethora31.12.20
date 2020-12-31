 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using plathora.Entity;
using plathora.Models;
using plathora.Models.Dtos;
using plathora.Services;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace plathora.API
{
    [Route("affilate")]
    //[ApiController]
    public class AffilateRegistrationAPI : ControllerBase
    {
        private readonly IAffiltateRegistrationService _AffiltateRegistrationService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AffilateRegistrationAPI(IAffiltateRegistrationService AffiltateRegistrationService, IWebHostEnvironment hostingEnvironment)
        {
            _AffiltateRegistrationService  = AffiltateRegistrationService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("affilateLogin")]
        public async Task<IActionResult> affilateLogin(string mobileNo,string password)
        {
            try
            {
                AffiltateRegistration obj = _AffiltateRegistrationService.GetAll().Where(x => x.mobileno1 == mobileNo && x.password == password).FirstOrDefault();
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(obj);
                }
                     
            }
            catch
            {
                return BadRequest();
            }
        }



        [HttpPost]
        [Route("Saveaffilate")]
        public async Task<IActionResult> Saveaffilate(AffiltateRegistrationDto model)
        {

            var checkduplicate = _AffiltateRegistrationService.GetAll().Where(x => x.mobileno1 == model.mobileno1 && x.isdeleted == false).FirstOrDefault();
            if (checkduplicate == null)
            {
                AffiltateRegistration obj = new AffiltateRegistration();


               // obj.id = model.id;
                obj.name = model.name;
               // obj.profilephoto = model.profilephoto;
                obj.mobileno1 = model.mobileno1;
                obj.mobileno2 = model.mobileno2;
                obj.emailid1 = model.emailid1;
                obj.emailid2 = model.emailid2;
                obj.adharcardno = model.adharcardno;
              //  obj.adharcardphoto = model.adharcardphoto;
                obj.pancardno = model.pancardno;
               //  obj.pancardphoto = model.pancardphoto;
                obj.password = model.password;
                 obj.gender = model.gender;
                obj.DOB = model.DOB;
                obj.createddate = DateTime.UtcNow;
                obj.isdeleted = false;
                obj.isactive = false;
                obj.house = model.house;
                obj.landmark = model.landmark;
                obj.street = model.street;
               obj.cityid = model.cityid;
               obj.zipcode = model.zipcode;
                obj.latitude = model.latitude;
                obj.longitude = model.longitude;
                obj.companyName = model.companyName;
               obj.designation = model.designation;
                obj.gstno = model.gstno;
                obj.Website = model.Website;
                obj.bankname = model.bankname;
                obj.accountname = model.accountname;
               obj.accountno = model.accountno;
               obj.ifsccode = model.ifsccode;
                obj.branch = model.branch;
            //   obj.passbookphoto = model.passbookphoto;
               obj.Membershipid = model.Membershipid;
               obj.amount = model.amount;
                obj.registerbyAffilateID = model.registerbyAffilateID;
                obj.deviceid = model.deviceid;


                if (model.profilephoto== null || model.profilephoto.Trim() == "")
                {
                    obj.profilephoto = "";
                }
                else
                {
                    
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\profilephoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.profilephoto));
                    obj.profilephoto = "/uploads/Affiltate/profilephoto/" + fileName;

                }
                if (model. adharcardphoto== null || model.adharcardphoto.Trim() == "")
                {
                    obj.adharcardphoto = "";
                }
                else
                {
                   
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\adharcardphoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.adharcardphoto));
                    obj.adharcardphoto = "/uploads/Affiltate/adharcardphoto/" + fileName;

                }
                if (model.pancardphoto ==null || model.pancardphoto.Trim() == "")
                {
                    obj.pancardphoto = "";
                }
                else
                {
                   
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\pancardphoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.pancardphoto));
                    obj.pancardphoto = "/uploads/Affiltate/pancardphoto/" + fileName;

                }
                if (model.passbookphoto== null || model.passbookphoto.Trim() == "")
                {
                    obj.passbookphoto = "";
                }
                else
                {
                   
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\passbookphoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.passbookphoto));
                    obj.passbookphoto = "/uploads/Affiltate/passbookphoto/" + fileName;

                }
                //if (ModelState.IsValid)
                //{
                    try
                    {
                        if (obj == null)
                        {
                            return NotFound();
                        }
                        else
                        {

                            var postId = await _AffiltateRegistrationService.CreateAsync(obj);
                            int id = Convert.ToInt32(postId);
                            if (id < 0)
                            {
                                return BadRequest();
                            }
                            else
                            {
                                var customer1 = _AffiltateRegistrationService.GetById(id);
                                return Ok(customer1);
                            }

                        }


                }
                    catch (Exception a)
                {

                    return BadRequest();
                }

            //}
            }
            else
            {
                return BadRequest("Duplicate Mobile No");
            }

            return BadRequest();
        }


        /*
    //        #region posman
    id: 111
        name: yogita
         profilephoto:ivborw0kggoaaaansuheugaaab8aaaalcayaaac6tzlyaaaaaxnsr0iars4c6qaaaarnqu1baacxjwv8yquaaaajcehzcwaadsmaaa7dacdvqgqaaabgsurbvfhhjzvlcbrvfia7jeyyirlig5njpdkzr2ymme6eiqesiefelr9ludgvpyxiq0iqcmwho1cucyiilfuqghgdwfgtdekklalykrhl1j265p2k8nvo6enj7z4o2fvftfe9t8///+d292j/ptepuxug/nlshec+lrexnvqepzhgpnfx8tpneqvbee9jqhmxrbb46xncpxcgdz877cxihu6onrt4/f513hojnjrspslo9odbhv+l8pnzuit/gh/nnabeevpghnetysb9/0lx7t0drgzenn2pc8qjbwhfgmztwj63dugh6b61nnquxmdw54goyj6ri8wek7ebtqni4pytwwtvgs2ihlfjr9wrxdnzuefuxavhzudgfqmsxmnaps8gcvntz7wsu01iqh7jtpcxubgstdazzks2x1ceojewlviwuwyovbiw5/ghdkw2zvjiprxn5x0utdslvvblixfjx6qtgmda+6ntzkc852udpfreqkiiqgj2wqph16unwujpwrhnzp81ujg4tn9e77zuvbqq6jmt8xpnzuhs2bp46cef8ompp+dmmtoynp7g1oqujk+frngiikmpkyd4hbbtselsz9uo7u/qfqf66igbm5vd/rj7/vt5gfskzhfvsmw+l06vwnitvwq/zv6nj3ypo2fb0qpu3lgh4t99+62vvcqsxfnz6vfue4nz2kza1+qq5y/czzs3cxh2l2zydryrtn7ugmxv3lmd0dfrr2kgxtjtqsjqerejsg8hor30bbffh995fcs3f+rg+vxriv7nqw8qcjas6jbuonevdw9ducel8kp2abdn/st6wsny8fontjz9gmvxruh27ds4dfkk42yvbif7jbyjrcogtjl+uje/n4rutycree0wrl69kuinrky8i6h4cberr/fgd0rqujz+bitdwsj0byhpr1y5glu3bmfkenhx873aqs65283wfodrpkavxv0qniptv0irofhw5m+4fpmyia8f/6qi6ekp3opuntwfycce7zndnyh/yvt48e1jzwfozmkxll0s8ephvqwozhvwgrfhvoyzvxlhwijtf+6x32g+vb8b3/1anm7vamnvw7gjr8s3lltqhncntvhv8+ttcotaopgrdp7ch3jng3f5udipdqszxxw5uigqxtu4xxzaf9stcouoox9a+d3m14mfan64ei+51zyyhb84/lfnssaddkf1kpfcstdczifcpo6qksnhnukloqtbgmccnmf4ac6iw0gzozjbwmwkqynjw+tahrar0y20sd6heislhha0taf+vi7lzq5mpzloup6nhezaza4kzmebozqu6bmnedjpopz4og/sjxmhlg6adnfv1bk2dvhnaf5q0tuls2arjcwivjpvo/vtuqxb4q1dbiikhigbcl5gyt4qtjhdzqmb3ya/pwsbhscnb3vkwtoqcuditjsuy4yhwgm6jpohbk1l8bietcsj+xxzpfloijpdih7kzxtqxf2dllisbmylutceeoyqskuucyjk4klax+lxzgwsorkpd5lolrteqdtfrxst+epbdbgsxoc/q0dtoo3gzarlwunoicxqgi+jodwoqlydlwqiypj5chehqsaao5t0m6c5javi6sasndybrixnt3tbwupu0u1gvibawfuh3pzuqepbxhthpgy/ehanbxh4m/q3scu5aauhstjmic7ekeq48ra0gd3jmrjmksxp78/oplqfncxtqa/vwqrmmfr4a2obm1hx+izl5vrunerbeuhbbuzksu5qoacl4xyjj4yerzphblmp+kn7oaws9jfpjugpp7ccbpypdp1m4e/tvmbptybld1ymh6xhchxlbzgogqyt9whri0tqs6qetrso0kgra01nymb5ggpt8ew0jx4ige9qyitctf0rmgvhk2huauf9wyc09w9nsvv4md30loodt+pab0bxt5uy4wjne6dp8ib6q7dhjkt29wp4qkzgqk7rx9amml7dh9ply1d/1afug/uyxcajlfu/hynu0z6ku/zw1q1aq3eqi5c1og6qg1je9ro6lbqg8+jomhiubk5t8ye6anqwkngvpabk9fxw1a/hphif26lhqti3ttl7nztar/o+huxmhfgp38ae1dubjc3naayfsis6jojdft5u1xc+7djsllxvtzxoj7cdii+irrozb7c6utohxkugaxuydsrudupr3uezroneff37zzyn1ff3fi1eley1uulj7mlwds/fmrlau/51rqhkkppyf4bgxrcf50xcon+gqgop+2grae0ndbogbpv2wxsyvo2dbmf/c6fvnc+jpwiaaaaasuvork5cyii=
        mobileno1:9146582495
        mobileno2: 9146582495
        // mobileno2:yogita@gmail.com
         emailid1: yogita @gmail.com
           emailid2:yogita @gmail.com
            adharcardno :ad no
         adharcardphoto: ivborw0kggoaaaansuheugaaab8aaaalcayaaac6tzlyaaaaaxnsr0iars4c6qaaaarnqu1baacxjwv8yquaaaajcehzcwaadsmaaa7dacdvqgqaaabgsurbvfhhjzvlcbrvfia7jeyyirlig5njpdkzr2ymme6eiqesiefelr9ludgvpyxiq0iqcmwho1cucyiilfuqghgdwfgtdekklalykrhl1j265p2k8nvo6enj7z4o2fvftfe9t8///+d292j/ptepuxug/nlshec+lrexnvqepzhgpnfx8tpneqvbee9jqhmxrbb46xncpxcgdz877cxihu6onrt4/f513hojnjrspslo9odbhv+l8pnzuit/gh/nnabeevpghnetysb9/0lx7t0drgzenn2pc8qjbwhfgmztwj63dugh6b61nnquxmdw54goyj6ri8wek7ebtqni4pytwwtvgs2ihlfjr9wrxdnzuefuxavhzudgfqmsxmnaps8gcvntz7wsu01iqh7jtpcxubgstdazzks2x1ceojewlviwuwyovbiw5/ghdkw2zvjiprxn5x0utdslvvblixfjx6qtgmda+6ntzkc852udpfreqkiiqgj2wqph16unwujpwrhnzp81ujg4tn9e77zuvbqq6jmt8xpnzuhs2bp46cef8ompp+dmmtoynp7g1oqujk+frngiikmpkyd4hbbtselsz9uo7u/qfqf66igbm5vd/rj7/vt5gfskzhfvsmw+l06vwnitvwq/zv6nj3ypo2fb0qpu3lgh4t99+62vvcqsxfnz6vfue4nz2kza1+qq5y/czzs3cxh2l2zydryrtn7ugmxv3lmd0dfrr2kgxtjtqsjqerejsg8hor30bbffh995fcs3f+rg+vxriv7nqw8qcjas6jbuonevdw9ducel8kp2abdn/st6wsny8fontjz9gmvxruh27ds4dfkk42yvbif7jbyjrcogtjl+uje/n4rutycree0wrl69kuinrky8i6h4cberr/fgd0rqujz+bitdwsj0byhpr1y5glu3bmfkenhx873aqs65283wfodrpkavxv0qniptv0irofhw5m+4fpmyia8f/6qi6ekp3opuntwfycce7zndnyh/yvt48e1jzwfozmkxll0s8ephvqwozhvwgrfhvoyzvxlhwijtf+6x32g+vb8b3/1anm7vamnvw7gjr8s3lltqhncntvhv8+ttcotaopgrdp7ch3jng3f5udipdqszxxw5uigqxtu4xxzaf9stcouoox9a+d3m14mfan64ei+51zyyhb84/lfnssaddkf1kpfcstdczifcpo6qksnhnukloqtbgmccnmf4ac6iw0gzozjbwmwkqynjw+tahrar0y20sd6heislhha0taf+vi7lzq5mpzloup6nhezaza4kzmebozqu6bmnedjpopz4og/sjxmhlg6adnfv1bk2dvhnaf5q0tuls2arjcwivjpvo/vtuqxb4q1dbiikhigbcl5gyt4qtjhdzqmb3ya/pwsbhscnb3vkwtoqcuditjsuy4yhwgm6jpohbk1l8bietcsj+xxzpfloijpdih7kzxtqxf2dllisbmylutceeoyqskuucyjk4klax+lxzgwsorkpd5lolrteqdtfrxst+epbdbgsxoc/q0dtoo3gzarlwunoicxqgi+jodwoqlydlwqiypj5chehqsaao5t0m6c5javi6sasndybrixnt3tbwupu0u1gvibawfuh3pzuqepbxhthpgy/ehanbxh4m/q3scu5aauhstjmic7ekeq48ra0gd3jmrjmksxp78/oplqfncxtqa/vwqrmmfr4a2obm1hx+izl5vrunerbeuhbbuzksu5qoacl4xyjj4yerzphblmp+kn7oaws9jfpjugpp7ccbpypdp1m4e/tvmbptybld1ymh6xhchxlbzgogqyt9whri0tqs6qetrso0kgra01nymb5ggpt8ew0jx4ige9qyitctf0rmgvhk2huauf9wyc09w9nsvv4md30loodt+pab0bxt5uy4wjne6dp8ib6q7dhjkt29wp4qkzgqk7rx9amml7dh9ply1d/1afug/uyxcajlfu/hynu0z6ku/zw1q1aq3eqi5c1og6qg1je9ro6lbqg8+jomhiubk5t8ye6anqwkngvpabk9fxw1a/hphif26lhqti3ttl7nztar/o+huxmhfgp38ae1dubjc3naayfsis6jojdft5u1xc+7djsllxvtzxoj7cdii+irrozb7c6utohxkugaxuydsrudupr3uezroneff37zzyn1ff3fi1eley1uulj7mlwds/fmrlau/51rqhkkppyf4bgxrcf50xcon+gqgop+2grae0ndbogbpv2wxsyvo2dbmf/c6fvnc+jpwiaaaaasuvork5cyii=
        pancardno:pan no
        pancardphoto: ivborw0kggoaaaansuheugaaab8aaaalcayaaac6tzlyaaaaaxnsr0iars4c6qaaaarnqu1baacxjwv8yquaaaajcehzcwaadsmaaa7dacdvqgqaaabgsurbvfhhjzvlcbrvfia7jeyyirlig5njpdkzr2ymme6eiqesiefelr9ludgvpyxiq0iqcmwho1cucyiilfuqghgdwfgtdekklalykrhl1j265p2k8nvo6enj7z4o2fvftfe9t8///+d292j/ptepuxug/nlshec+lrexnvqepzhgpnfx8tpneqvbee9jqhmxrbb46xncpxcgdz877cxihu6onrt4/f513hojnjrspslo9odbhv+l8pnzuit/gh/nnabeevpghnetysb9/0lx7t0drgzenn2pc8qjbwhfgmztwj63dugh6b61nnquxmdw54goyj6ri8wek7ebtqni4pytwwtvgs2ihlfjr9wrxdnzuefuxavhzudgfqmsxmnaps8gcvntz7wsu01iqh7jtpcxubgstdazzks2x1ceojewlviwuwyovbiw5/ghdkw2zvjiprxn5x0utdslvvblixfjx6qtgmda+6ntzkc852udpfreqkiiqgj2wqph16unwujpwrhnzp81ujg4tn9e77zuvbqq6jmt8xpnzuhs2bp46cef8ompp+dmmtoynp7g1oqujk+frngiikmpkyd4hbbtselsz9uo7u/qfqf66igbm5vd/rj7/vt5gfskzhfvsmw+l06vwnitvwq/zv6nj3ypo2fb0qpu3lgh4t99+62vvcqsxfnz6vfue4nz2kza1+qq5y/czzs3cxh2l2zydryrtn7ugmxv3lmd0dfrr2kgxtjtqsjqerejsg8hor30bbffh995fcs3f+rg+vxriv7nqw8qcjas6jbuonevdw9ducel8kp2abdn/st6wsny8fontjz9gmvxruh27ds4dfkk42yvbif7jbyjrcogtjl+uje/n4rutycree0wrl69kuinrky8i6h4cberr/fgd0rqujz+bitdwsj0byhpr1y5glu3bmfkenhx873aqs65283wfodrpkavxv0qniptv0irofhw5m+4fpmyia8f/6qi6ekp3opuntwfycce7zndnyh/yvt48e1jzwfozmkxll0s8ephvqwozhvwgrfhvoyzvxlhwijtf+6x32g+vb8b3/1anm7vamnvw7gjr8s3lltqhncntvhv8+ttcotaopgrdp7ch3jng3f5udipdqszxxw5uigqxtu4xxzaf9stcouoox9a+d3m14mfan64ei+51zyyhb84/lfnssaddkf1kpfcstdczifcpo6qksnhnukloqtbgmccnmf4ac6iw0gzozjbwmwkqynjw+tahrar0y20sd6heislhha0taf+vi7lzq5mpzloup6nhezaza4kzmebozqu6bmnedjpopz4og/sjxmhlg6adnfv1bk2dvhnaf5q0tuls2arjcwivjpvo/vtuqxb4q1dbiikhigbcl5gyt4qtjhdzqmb3ya/pwsbhscnb3vkwtoqcuditjsuy4yhwgm6jpohbk1l8bietcsj+xxzpfloijpdih7kzxtqxf2dllisbmylutceeoyqskuucyjk4klax+lxzgwsorkpd5lolrteqdtfrxst+epbdbgsxoc/q0dtoo3gzarlwunoicxqgi+jodwoqlydlwqiypj5chehqsaao5t0m6c5javi6sasndybrixnt3tbwupu0u1gvibawfuh3pzuqepbxhthpgy/ehanbxh4m/q3scu5aauhstjmic7ekeq48ra0gd3jmrjmksxp78/oplqfncxtqa/vwqrmmfr4a2obm1hx+izl5vrunerbeuhbbuzksu5qoacl4xyjj4yerzphblmp+kn7oaws9jfpjugpp7ccbpypdp1m4e/tvmbptybld1ymh6xhchxlbzgogqyt9whri0tqs6qetrso0kgra01nymb5ggpt8ew0jx4ige9qyitctf0rmgvhk2huauf9wyc09w9nsvv4md30loodt+pab0bxt5uy4wjne6dp8ib6q7dhjkt29wp4qkzgqk7rx9amml7dh9ply1d/1afug/uyxcajlfu/hynu0z6ku/zw1q1aq3eqi5c1og6qg1je9ro6lbqg8+jomhiubk5t8ye6anqwkngvpabk9fxw1a/hphif26lhqti3ttl7nztar/o+huxmhfgp38ae1dubjc3naayfsis6jojdft5u1xc+7djsllxvtzxoj7cdii+irrozb7c6utohxkugaxuydsrudupr3uezroneff37zzyn1ff3fi1eley1uulj7mlwds/fmrlau/51rqhkkppyf4bgxrcf50xcon+gqgop+2grae0ndbogbpv2wxsyvo2dbmf/c6fvnc+jpwiaaaaasuvork5cyii=
        password:123
        gender: 1
        dob: 06 / 08 / 2020
        createddate: 06 / 08 / 2020
        isdeleted: false
        isactive: false
        house: house
         landmark:landmark
         street:street
         cityid:1
        zipcode: 42222
        latitude: 32
        longitude: 324
        companyname: compamy name
        designation: design
         gstno:gst
         website:website
         bankname:bank name
        accountname: acc nmae
        accountno: acc no
        ifsccode: ifsc
         branch:branch
         passbookphoto:ivborw0kggoaaaansuheugaaab8aaaalcayaaac6tzlyaaaaaxnsr0iars4c6qaaaarnqu1baacxjwv8yquaaaajcehzcwaadsmaaa7dacdvqgqaaabgsurbvfhhjzvlcbrvfia7jeyyirlig5njpdkzr2ymme6eiqesiefelr9ludgvpyxiq0iqcmwho1cucyiilfuqghgdwfgtdekklalykrhl1j265p2k8nvo6enj7z4o2fvftfe9t8///+d292j/ptepuxug/nlshec+lrexnvqepzhgpnfx8tpneqvbee9jqhmxrbb46xncpxcgdz877cxihu6onrt4/f513hojnjrspslo9odbhv+l8pnzuit/gh/nnabeevpghnetysb9/0lx7t0drgzenn2pc8qjbwhfgmztwj63dugh6b61nnquxmdw54goyj6ri8wek7ebtqni4pytwwtvgs2ihlfjr9wrxdnzuefuxavhzudgfqmsxmnaps8gcvntz7wsu01iqh7jtpcxubgstdazzks2x1ceojewlviwuwyovbiw5/ghdkw2zvjiprxn5x0utdslvvblixfjx6qtgmda+6ntzkc852udpfreqkiiqgj2wqph16unwujpwrhnzp81ujg4tn9e77zuvbqq6jmt8xpnzuhs2bp46cef8ompp+dmmtoynp7g1oqujk+frngiikmpkyd4hbbtselsz9uo7u/qfqf66igbm5vd/rj7/vt5gfskzhfvsmw+l06vwnitvwq/zv6nj3ypo2fb0qpu3lgh4t99+62vvcqsxfnz6vfue4nz2kza1+qq5y/czzs3cxh2l2zydryrtn7ugmxv3lmd0dfrr2kgxtjtqsjqerejsg8hor30bbffh995fcs3f+rg+vxriv7nqw8qcjas6jbuonevdw9ducel8kp2abdn/st6wsny8fontjz9gmvxruh27ds4dfkk42yvbif7jbyjrcogtjl+uje/n4rutycree0wrl69kuinrky8i6h4cberr/fgd0rqujz+bitdwsj0byhpr1y5glu3bmfkenhx873aqs65283wfodrpkavxv0qniptv0irofhw5m+4fpmyia8f/6qi6ekp3opuntwfycce7zndnyh/yvt48e1jzwfozmkxll0s8ephvqwozhvwgrfhvoyzvxlhwijtf+6x32g+vb8b3/1anm7vamnvw7gjr8s3lltqhncntvhv8+ttcotaopgrdp7ch3jng3f5udipdqszxxw5uigqxtu4xxzaf9stcouoox9a+d3m14mfan64ei+51zyyhb84/lfnssaddkf1kpfcstdczifcpo6qksnhnukloqtbgmccnmf4ac6iw0gzozjbwmwkqynjw+tahrar0y20sd6heislhha0taf+vi7lzq5mpzloup6nhezaza4kzmebozqu6bmnedjpopz4og/sjxmhlg6adnfv1bk2dvhnaf5q0tuls2arjcwivjpvo/vtuqxb4q1dbiikhigbcl5gyt4qtjhdzqmb3ya/pwsbhscnb3vkwtoqcuditjsuy4yhwgm6jpohbk1l8bietcsj+xxzpfloijpdih7kzxtqxf2dllisbmylutceeoyqskuucyjk4klax+lxzgwsorkpd5lolrteqdtfrxst+epbdbgsxoc/q0dtoo3gzarlwunoicxqgi+jodwoqlydlwqiypj5chehqsaao5t0m6c5javi6sasndybrixnt3tbwupu0u1gvibawfuh3pzuqepbxhthpgy/ehanbxh4m/q3scu5aauhstjmic7ekeq48ra0gd3jmrjmksxp78/oplqfncxtqa/vwqrmmfr4a2obm1hx+izl5vrunerbeuhbbuzksu5qoacl4xyjj4yerzphblmp+kn7oaws9jfpjugpp7ccbpypdp1m4e/tvmbptybld1ymh6xhchxlbzgogqyt9whri0tqs6qetrso0kgra01nymb5ggpt8ew0jx4ige9qyitctf0rmgvhk2huauf9wyc09w9nsvv4md30loodt+pab0bxt5uy4wjne6dp8ib6q7dhjkt29wp4qkzgqk7rx9amml7dh9ply1d/1afug/uyxcajlfu/hynu0z6ku/zw1q1aq3eqi5c1og6qg1je9ro6lbqg8+jomhiubk5t8ye6anqwkngvpabk9fxw1a/hphif26lhqti3ttl7nztar/o+huxmhfgp38ae1dubjc3naayfsis6jojdft5u1xc+7djsllxvtzxoj7cdii+irrozb7c6utohxkugaxuydsrudupr3uezroneff37zzyn1ff3fi1eley1uulj7mlwds/fmrlau/51rqhkkppyf4bgxrcf50xcon+gqgop+2grae0ndbogbpv2wxsyvo2dbmf/c6fvnc+jpwiaaaaasuvork5cyii=
        membershipid:1
        amount: 500
        registerbyaffilateid: 1
        deviceid: 3123
        //                #endregion

        */

        //[HttpPut]
        //[Route("updateaffilateDeviceId")]
        //public async Task<IActionResult> updateaffilateDeviceId([FromUri] string deviceId, [FromUri] int id)
        //{
        //    var customer = _AffiltateRegistrationService.GetById(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        customer.deviceid = deviceId;
        //        await _AffiltateRegistrationService.UpdateAsync(customer);

        //        if (id < 0)
        //        {
        //            return BadRequest();
        //        }
        //        else
        //        {

        //            return Ok(customer);
        //        }
        //    }



        //    return BadRequest();
        //}


        [HttpPut]
        [Route("updateAffilate")]
        public async Task<IActionResult> updateAffilate(AffiltateRegistrationDto model)
        {

            var checkduplicate = _AffiltateRegistrationService.GetAll().Where(x => x.mobileno1 == model.mobileno1 && x.isdeleted == false && x.id != model.id).FirstOrDefault();
            if (checkduplicate == null)
            {
                AffiltateRegistration obj = _AffiltateRegistrationService.GetById(model.id);
                // obj.id = model.id;
                obj.name = model.name;
                // obj.profilephoto = model.profilephoto;
                obj.mobileno1 = model.mobileno1;
                obj.mobileno2 = model.mobileno2;
                obj.emailid1 = model.emailid1;
                obj.emailid2 = model.emailid2;
                obj.adharcardno = model.adharcardno;
                //  obj.adharcardphoto = model.adharcardphoto;
                obj.pancardno = model.pancardno;
                //  obj.pancardphoto = model.pancardphoto;
                obj.password = model.password;
                obj.gender = model.gender;
                obj.DOB = model.DOB;
                obj.createddate = DateTime.UtcNow;
                obj.isdeleted = false;
                obj.isactive = false;
                obj.house = model.house;
                obj.landmark = model.landmark;
                obj.street = model.street;
                obj.cityid = model.cityid;
                obj.zipcode = model.zipcode;
                obj.latitude = model.latitude;
                obj.longitude = model.longitude;
                obj.companyName = model.companyName;
                obj.designation = model.designation;
                obj.gstno = model.gstno;
                obj.Website = model.Website;
                obj.bankname = model.bankname;
                obj.accountname = model.accountname;
                obj.accountno = model.accountno;
                obj.ifsccode = model.ifsccode;
                obj.branch = model.branch;
                //   obj.passbookphoto = model.passbookphoto;
                obj.Membershipid = model.Membershipid;
                obj.amount = model.amount;
                obj.registerbyAffilateID = model.registerbyAffilateID;
                obj.deviceid = model.deviceid;


                if (model.profilephoto== null || model.profilephoto.Trim()=="")
                {
                   

                }
                else
                {
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\profilephoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.profilephoto));
                    obj.profilephoto = "/uploads/Affiltate/profilephoto/" + fileName;
                }
                 
                if (model.adharcardphoto == null || model.adharcardphoto.Trim() == "")
                {
                  
                }
                else
                {
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\adharcardphoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.adharcardphoto));
                    obj.adharcardphoto = "/uploads/Affiltate/adharcardphoto/" + fileName;

                }
                if (model.pancardphoto == null || model.pancardphoto.Trim() == "")
                {
                 
                }
                else
                {
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\pancardphoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.pancardphoto));
                    obj.pancardphoto = "/uploads/Affiltate/pancardphoto/" + fileName;

                }

                if (model.passbookphoto== null || model.passbookphoto.Trim() == "")
                {
                   
                }
                else
                {
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\passbookphoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.passbookphoto));
                    obj.passbookphoto = "/uploads/Affiltate/passbookphoto/" + fileName;

                }



                //if (ModelState.IsValid)
                //{
                    try
                    {
                        if (obj == null)
                        {
                            return NotFound();
                        }
                        else
                        {

                            await _AffiltateRegistrationService.UpdateAsync(obj);


                            return Ok(obj);


                        }


                    }
                    catch (Exception)
                    {

                        return BadRequest();
                    }

                //}
            }
            else
            {
                return BadRequest("Duplicate Mobile No");
            }

            return BadRequest();
        }



        [System.Web.Http.HttpPatch]
        [Route("updateAffilateUsingPatch")]
        public async Task<IActionResult> updateAffilateUsingPatch(AffiltateRegistrationDto model)
        {

            var checkduplicate = _AffiltateRegistrationService.GetAll().Where(x => x.mobileno1 == model.mobileno1 && x.isdeleted == false && x.id != model.id).FirstOrDefault();
            if (checkduplicate == null)
            {
                AffiltateRegistration obj = _AffiltateRegistrationService.GetById(model.id);
                // obj.id = model.id;
                obj.name = model.name;
                // obj.profilephoto = model.profilephoto;
                obj.mobileno1 = model.mobileno1;
                obj.mobileno2 = model.mobileno2;
                obj.emailid1 = model.emailid1;
                obj.emailid2 = model.emailid2;
                obj.adharcardno = model.adharcardno;
                //  obj.adharcardphoto = model.adharcardphoto;
                obj.pancardno = model.pancardno;
                //  obj.pancardphoto = model.pancardphoto;
                obj.password = model.password;
                obj.gender = model.gender;
                obj.DOB = model.DOB;
                obj.createddate = DateTime.UtcNow;
                obj.isdeleted = false;
                obj.isactive = false;
                obj.house = model.house;
                obj.landmark = model.landmark;
                obj.street = model.street;
                obj.cityid = model.cityid;
                obj.zipcode = model.zipcode;
                obj.latitude = model.latitude;
                obj.longitude = model.longitude;
                obj.companyName = model.companyName;
                obj.designation = model.designation;
                obj.gstno = model.gstno;
                obj.Website = model.Website;
                obj.bankname = model.bankname;
                obj.accountname = model.accountname;
                obj.accountno = model.accountno;
                obj.ifsccode = model.ifsccode;
                obj.branch = model.branch;
                //   obj.passbookphoto = model.passbookphoto;
                obj.Membershipid = model.Membershipid;
                obj.amount = model.amount;
                obj.registerbyAffilateID = model.registerbyAffilateID;
                obj.deviceid = model.deviceid;


                if (model.profilephoto == null || model.profilephoto.Trim() == "")
                {


                }
                else
                {
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\profilephoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.profilephoto));
                    obj.profilephoto = "/uploads/Affiltate/profilephoto/" + fileName;
                }

                if (model.adharcardphoto == null || model.adharcardphoto.Trim() == "")
                {

                }
                else
                {
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\adharcardphoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.adharcardphoto));
                    obj.adharcardphoto = "/uploads/Affiltate/adharcardphoto/" + fileName;

                }
                if (model.pancardphoto == null || model.pancardphoto.Trim() == "")
                {

                }
                else
                {
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\pancardphoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.pancardphoto));
                    obj.pancardphoto = "/uploads/Affiltate/pancardphoto/" + fileName;

                }

                if (model.passbookphoto == null || model.passbookphoto.Trim() == "")
                {

                }
                else
                {
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\Affiltate\passbookphoto";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.passbookphoto));
                    obj.passbookphoto = "/uploads/Affiltate/passbookphoto/" + fileName;

                }



                //if (ModelState.IsValid)
                //{
                try
                {
                    if (obj == null)
                    {
                        return NotFound();
                    }
                    else
                    {

                        await _AffiltateRegistrationService.UpdateAsync(obj);


                        return Ok(obj);


                    }


                }
                catch (Exception)
                {

                    return BadRequest();
                }

                //}
            }
            else
            {
                return BadRequest("Duplicate Mobile No");
            }

            return BadRequest();
        }


        [HttpGet]
        [Route("getOTPNo")]
        public async Task<IActionResult> getOTPNo(string mobileno)
        {
            try
            {

                String no = null;
                Random random = new Random();
                for (int i = 0; i < 1; i++)
                {
                    int n = random.Next(0, 999);
                    no += n.ToString("D4") + "";
                }
                #region "sms"
                try
                {

                    string Msg = "OTP :" + no + ".  Please Use this OTP.This is usable once and expire in 10 minutes";

                    string OPTINS = "STRLIT";

                    string type = "3";
                    string strUrl = "https://www.bulksmsgateway.in/sendmessage.php?user=ezacus&password=" + "Bingo@5151" + "&message=" + Msg.ToString() + "&sender=" + OPTINS + "&mobile=" + mobileno + "&type=" + 3;

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();
                    //    Response.Write("Sent");
                }

                catch
                { }
                #endregion

                AffiltateRegistrationOTPModel objAffiltateRegistrationOTPModel = new AffiltateRegistrationOTPModel();
                AffiltateRegistration obj = _AffiltateRegistrationService.GetAll().Where(x => x.mobileno1 == mobileno && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj!= null)
                {

                    
              
                    objAffiltateRegistrationOTPModel.id = obj.id;

                    objAffiltateRegistrationOTPModel.name = obj.name;
                    objAffiltateRegistrationOTPModel.profilephoto = obj.profilephoto;
                    
                    objAffiltateRegistrationOTPModel.mobileno1 = obj.mobileno1;
                    objAffiltateRegistrationOTPModel.mobileno2 = obj.mobileno2;
                    objAffiltateRegistrationOTPModel.emailid1 = obj.emailid1;
                    objAffiltateRegistrationOTPModel.emailid2 = obj.emailid2;
                    objAffiltateRegistrationOTPModel.adharcardno = obj.adharcardno;
                    objAffiltateRegistrationOTPModel.adharcardphoto = obj.adharcardphoto;

                    objAffiltateRegistrationOTPModel.pancardno = obj.pancardno;
                    objAffiltateRegistrationOTPModel.pancardphoto =  obj.pancardphoto;
                    objAffiltateRegistrationOTPModel.password = obj.password;
                    objAffiltateRegistrationOTPModel.gender = obj.gender;
                   
                    objAffiltateRegistrationOTPModel.otpno = no;

                    objAffiltateRegistrationOTPModel.DOB = obj.DOB;
                    objAffiltateRegistrationOTPModel.createddate = obj.createddate;
                    objAffiltateRegistrationOTPModel.isdeleted = obj.isdeleted;
                    objAffiltateRegistrationOTPModel.isactive = obj.isactive;
                    objAffiltateRegistrationOTPModel.house = obj.house;
                    objAffiltateRegistrationOTPModel.landmark = obj.landmark;
                    objAffiltateRegistrationOTPModel.street = obj.street ;
                    objAffiltateRegistrationOTPModel.cityid = obj.cityid;
                    objAffiltateRegistrationOTPModel.zipcode = obj.zipcode;
                    objAffiltateRegistrationOTPModel.latitude = obj.latitude;
                    objAffiltateRegistrationOTPModel.longitude = obj.longitude;
                    objAffiltateRegistrationOTPModel.companyName = obj.companyName;
                    objAffiltateRegistrationOTPModel.designation = obj.designation;
                    objAffiltateRegistrationOTPModel.gstno = obj.gstno;
                    objAffiltateRegistrationOTPModel.Website = obj.Website ;
                    objAffiltateRegistrationOTPModel.bankname = obj.bankname;
                    objAffiltateRegistrationOTPModel.accountname = obj.accountname;
                    objAffiltateRegistrationOTPModel.accountno = obj.accountno;
                    objAffiltateRegistrationOTPModel.ifsccode = obj.ifsccode;
                    objAffiltateRegistrationOTPModel.branch = obj.branch ;
                    objAffiltateRegistrationOTPModel.passbookphoto = obj.passbookphoto;
                    objAffiltateRegistrationOTPModel.Membershipid = obj.Membershipid;
                    objAffiltateRegistrationOTPModel.amount = obj.amount ;
                    objAffiltateRegistrationOTPModel.registerbyAffilateID = obj.registerbyAffilateID;
                    objAffiltateRegistrationOTPModel.deviceid = obj.deviceid;
                    return Ok(objAffiltateRegistrationOTPModel);
                }
                else
                {
                    objAffiltateRegistrationOTPModel.otpno = no;
                    return Ok(objAffiltateRegistrationOTPModel);
                }

            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }



    }
}
