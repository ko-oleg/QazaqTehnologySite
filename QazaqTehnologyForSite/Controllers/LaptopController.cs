using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QazaqTehnologyForSite.Models;
using QazaqTehnologyForSite.Models.Laptops;
using OperatingSystem = QazaqTehnologyForSite.Models.Laptops.OperatingSystem;

namespace QazaqTehnologyForSite.Controllers
{
    [Route("/api/[controller]")]
    public class LaptopController : Controller
    {
        private ApplicationContext _db;
        
        public LaptopController(ApplicationContext context)
        {
            _db = context;
        }
        //GET
        // public IActionResult Index()
        // {
        //     return View();
        // }
        
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _db.Laptops.ToListAsync());
        }

        [HttpGet("GetAllLaptops")]
        public IActionResult GetAllLaptops()
        {
            var laptops = _db.Laptops
                .Include(laptop => laptop.Processors)
                .Include(laptop => laptop.RamMemory)
                .Include(laptop => laptop.SsdMemory)
                .Include(laptop => laptop.Display)
                .Include(laptop => laptop.Ports)
                .Include(laptop => laptop.WirelessConnection)
                .Include(laptop => laptop.NetworkController)
                .Include(laptop => laptop.SecurityLock)
                .Include(laptop => laptop.OperatingSystem)
                .Include(laptop => laptop.Set)
                .Include(laptop => laptop.Keyboard);
            return Ok(laptops);
        }
        
        [HttpGet("GetLaptopById")]
        public IActionResult GetLaptopById(int id)
        {
            var laptops = _db.Laptops
                .Include(laptop => laptop.Processors)
                .Include(laptop => laptop.RamMemory)
                .Include(laptop => laptop.SsdMemory)
                .Include(laptop => laptop.Display)
                .Include(laptop => laptop.Ports)
                .Include(laptop => laptop.WirelessConnection)
                .Include(laptop => laptop.NetworkController)
                .Include(laptop => laptop.SecurityLock)
                .Include(laptop => laptop.OperatingSystem)
                .Include(laptop => laptop.Set)
                .Include(laptop => laptop.Keyboard).FirstOrDefault(u => u.Id == id);
            return Ok(laptops);
        }
        
        // Laptop //
        
        [HttpGet("CreateLaptop")]
        public IActionResult CreateLaptop()
        {
            return View();
        }
        [HttpPost("CreateLaptop")]
        public async Task<IActionResult> CreateLaptop(Laptop laptop)
        {
            _db.Laptops.Add(laptop);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        [HttpPut("EditLaptop")]
        public async Task<IActionResult> EditLaptop(Laptop laptop)
        {
            _db.Laptops.Update(laptop);
            await _db.SaveChangesAsync();
            return Ok(laptop);
        }
        
        [HttpDelete("DeleteLaptop")]
        public async Task<IActionResult> DeleteLaptop(int? id)
        {
            if (id != null)
            {
                Laptop laptop = await _db.Laptops.FirstOrDefaultAsync(p => p.Id == id);
                if (laptop != null)
                {
                    _db.Laptops.Remove(laptop);
                    await _db.SaveChangesAsync();
                    return Ok(laptop);
                }
            }
            return NotFound();
        }
        
        // Processor //
        
        [HttpGet("GoToCreateProcessor")]
        public RedirectToActionResult GoToCreateProcessor()
        {
            return RedirectToAction("CreateProcessor");
        }
        
        [HttpGet("GoToViewAllProcessors")]
        public RedirectToActionResult GoToViewAllProcessors()
        {
            return RedirectToAction("ViewAllProcessors");
        }
        
        [HttpGet("ViewAllProcessors")]
        public async Task<IActionResult> ViewAllProcessors()
        {
            return View(await _db.Processors.ToListAsync());
        }

        [HttpGet("CreateProcessor")]
        public IActionResult CreateProcessor()
        {
            return View();
        }
        [HttpPost("CreateProcessor")]
        public async Task<IActionResult> CreateProcessor(Processor processor)
        {
            _db.Processors.Add(processor);
            await _db.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPut("EditProcessor")]
        public async Task<IActionResult> EditProcessor(Processor processor)
        {
            _db.Processors.Update(processor);
            await _db.SaveChangesAsync();
            return Ok(processor);
        }
        
        [HttpDelete("DeleteProcessor")]
        public async Task<IActionResult> DeleteProcessor(int? id)
        {
            if (id != null)
            {
                Processor processor = await _db.Processors.FirstOrDefaultAsync(p => p.Id == id);
                if (processor != null)
                {
                    _db.Processors.Remove(processor);
                    await _db.SaveChangesAsync();
                    return Ok(processor);
                }
            }
            return NotFound();
        }
        
        [HttpPost("TakeProcessorsIdForLaptop")]
        public IActionResult TakeProcessorsIdForLaptop(int idLaptop,int idProc)
        {
            var includProc = _db.Processors.SingleOrDefault(p => p.Id == idProc);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.Processors.Add(includProc);
            _db.SaveChanges();
            return Ok();
        }
        
        // RAMMemory //
        
        [HttpPost("CreateRAMMemory")]
        public async Task<IActionResult> CreateRAMMemory(RAMMemory ramMemory)
        {
            _db.RamMemories.Add(ramMemory);
            await _db.SaveChangesAsync();
            return Ok(ramMemory);
        }
        
        [HttpPut("EditRAMMemory")]
        public async Task<IActionResult> EditRAMMemory(RAMMemory ramMemory)
        {
            _db.RamMemories.Update(ramMemory);
            await _db.SaveChangesAsync();
            return Ok(ramMemory);
        }
        
        [HttpDelete("DeleteRAMMemory")]
        public async Task<IActionResult> DeleteRAMMemory(int? id)
        {
            if (id != null)
            {
                RAMMemory ramMemory = await _db.RamMemories.FirstOrDefaultAsync(p => p.Id == id);
                if (ramMemory != null)
                {
                    _db.RamMemories.Remove(ramMemory);
                    await _db.SaveChangesAsync();
                    return Ok(ramMemory);
                }
            }
            return NotFound();
        }
        
        [HttpPost("TakeRAMMemoryIdForLaptop")]
        public IActionResult TakeRAMMemoryIdForLaptop(int idLaptop,int idRam)
        {
            var includRam = _db.RamMemories.SingleOrDefault(p => p.Id == idRam);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.RamMemory.Add(includRam);
            _db.SaveChanges();
            return Ok();
        }
        
        // SSDMemory //
        
        [HttpPost("CreateSSDMemory")]
        public async Task<IActionResult> CreateSSDMemory(SSDMemory ssdMemory)
        {
            _db.SsdMemories.Add(ssdMemory);
            await _db.SaveChangesAsync();
            return Ok(ssdMemory);
        }
        
        [HttpPut("EditSSDMemory")]
        public async Task<IActionResult> EditSSDMemory(SSDMemory ssdMemory)
        {
            _db.SsdMemories.Update(ssdMemory);
            await _db.SaveChangesAsync();
            return Ok(ssdMemory);
        }
        
        [HttpDelete("DeleteSSDMemory")]
        public async Task<IActionResult> DeleteSSDMemory(int? id)
        {
            if (id != null)
            {
                SSDMemory ssdMemory = await _db.SsdMemories.FirstOrDefaultAsync(p => p.Id == id);
                if (ssdMemory != null)
                {
                    _db.SsdMemories.Remove(ssdMemory);
                    await _db.SaveChangesAsync();
                    return Ok(ssdMemory);
                }
            }
            return NotFound();
        }
        
        [HttpPost("TakeSSDMemoryIdForLaptop")]
        public IActionResult TakeSSDMemoryIdForLaptop(int idLaptop,int idSsd)
        {
            var includSsd = _db.SsdMemories.SingleOrDefault(p => p.Id == idSsd);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.SsdMemory.Add(includSsd);
            _db.SaveChanges();
            return Ok();
        }
        
        // Display //
        
        [HttpPost("CreateDisplay")]
        public async Task<IActionResult> CreateDisplay(Display display)
        {
            _db.Displays.Add(display);
            await _db.SaveChangesAsync();
            return Ok(display);
        }
        
        [HttpPut("EditDisplay")]
        public async Task<IActionResult> EditDisplay(Display display)
        {
            _db.Displays.Update(display);
            await _db.SaveChangesAsync();
            return Ok(display);
        }
        
        [HttpDelete("DeleteDisplay")]
        public async Task<IActionResult> DeleteDisplay(int? id)
        {
            if (id != null)
            {
                Display display = await _db.Displays.FirstOrDefaultAsync(p => p.Id == id);
                if (display != null)
                {
                    _db.Displays.Remove(display);
                    await _db.SaveChangesAsync();
                    return Ok(display);
                }
            }
            return NotFound();
        }
        
        [HttpPost("TakeDisplayIdForLaptop")]
        public IActionResult TakeDisplayIdForLaptop(int idLaptop,int idDisplay)
        {
            var includDisplay = _db.Displays.SingleOrDefault(p => p.Id == idDisplay);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.Display.Add(includDisplay);
            _db.SaveChanges();
            return Ok();
        }
        
        // Ports
        
        [HttpPost("CreatePorts")]
        public async Task<IActionResult> CreatePorts(Ports ports)
        {
            _db.Ports.Add(ports);
            await _db.SaveChangesAsync();
            return Ok(ports);
        }
        
        [HttpPut("EditPorts")]
        public async Task<IActionResult> EditPorts(Ports ports)
        {
            _db.Ports.Update(ports);
            await _db.SaveChangesAsync();
            return Ok(ports);
        }
        
        [HttpDelete("DeletePorts")]
        public async Task<IActionResult> DeletePorts(int? id)
        {
            if (id != null)
            {
                Ports ports = await _db.Ports.FirstOrDefaultAsync(p => p.Id == id);
                if (ports != null)
                {
                    _db.Ports.Remove(ports);
                    await _db.SaveChangesAsync();
                    return Ok(ports);
                }
            }
            return NotFound();
        }
        
        [HttpPost("TakePortsIdForLaptop")]
        public IActionResult TakePortsIdForLaptop(int idLaptop,int idPorts)
        {
            var includPorts = _db.Ports.SingleOrDefault(p => p.Id == idPorts);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.Ports.Add(includPorts);      
            _db.SaveChanges();
            return Ok();
        }
        
        // WirelessConnections //
        
        [HttpPost("CreateWirelessConnections")]
        public async Task<IActionResult> CreateWirelessConnections(WirelessConnection wirelessConnection)
        {
            _db.WirelessConnections.Add(wirelessConnection);
            await _db.SaveChangesAsync();
            return Ok(wirelessConnection);
        }
        
        [HttpPut("EditWirelessConnections")]
        public async Task<IActionResult> EditWirelessConnections(WirelessConnection wirelessConnection)
        {
            _db.WirelessConnections.Update(wirelessConnection);
            await _db.SaveChangesAsync();
            return Ok(wirelessConnection);
        }
        
        [HttpDelete("DeleteWirelessConnections")]
        public async Task<IActionResult> DeleteWirelessConnections(int? id)
        {
            if (id != null)
            {
                WirelessConnection wirelessConnection = await _db.WirelessConnections.FirstOrDefaultAsync(p => p.Id == id);
                if (wirelessConnection != null)
                {
                    _db.WirelessConnections.Remove(wirelessConnection);
                    await _db.SaveChangesAsync();
                    return Ok(wirelessConnection);
                }
            }
            return NotFound();
        }
        
        [HttpPost("TakeWirelessConnectionsIdForLaptop")]
        public IActionResult TakeWirelessConnectionsIdForLaptop(int idLaptop,int idWireless)
        {
            var includWirelessConnection = _db.WirelessConnections.SingleOrDefault(p => p.Id == idWireless);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.WirelessConnection.Add(includWirelessConnection);      
            _db.SaveChanges();
            return Ok();
        }
        
        // Network Controllers //
        
        [HttpPost("CreateNetworkController")]
        public async Task<IActionResult> CreateNetworkController(NetworkController networkController)
        {
            _db.NetworkControllers.Add(networkController);
            await _db.SaveChangesAsync();
            return Ok(networkController);
        }
        
        [HttpPut("EditNetworkController")]
        public async Task<IActionResult> EditNetworkController(NetworkController networkController)
        {
            _db.NetworkControllers.Update(networkController);
            await _db.SaveChangesAsync();
            return Ok(networkController);
        }
        
        [HttpDelete("DeleteNetworkController")]
        public async Task<IActionResult> DeleteNetworkController(int? id)
        {
            if (id != null)
            {
                NetworkController networkController = await _db.NetworkControllers.FirstOrDefaultAsync(p => p.Id == id);
                if (networkController != null)
                {
                    _db.NetworkControllers.Remove(networkController);
                    await _db.SaveChangesAsync();
                    return Ok(networkController);
                }
            }
            return NotFound();
        }
        
        [HttpPost("TakeNetworkControllerIdForLaptop")]
        public IActionResult TakeNetworkControllerIdForLaptop(int idLaptop,int idNetCont)
        {
            var includNetworkController = _db.NetworkControllers.SingleOrDefault(p => p.Id == idNetCont);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.NetworkController.Add(includNetworkController);      
            _db.SaveChanges();
            return Ok();
        }
        
        // SecurityLock //
        
        [HttpPost("CreateSecurityLock")]
        public async Task<IActionResult> CreateSecurityLock(SecurityLock securityLock)
        {
            _db.SecurityLocks.Add(securityLock);
            await _db.SaveChangesAsync();
            return Ok(securityLock);
        }
        
        [HttpPut("EditSecurityLock")]
        public async Task<IActionResult> EditSecurityLock(SecurityLock securityLock)
        {
            _db.SecurityLocks.Update(securityLock);
            await _db.SaveChangesAsync();
            return Ok(securityLock);
        }
        
        [HttpDelete("DeleteSecurityLock")]
        public async Task<IActionResult> DeleteSecurityLock(int? id)
        {
            if (id != null)
            {
                SecurityLock securityLock = await _db.SecurityLocks.FirstOrDefaultAsync(p => p.Id == id);
                if (securityLock != null)
                {
                    _db.SecurityLocks.Remove(securityLock);
                    await _db.SaveChangesAsync();
                    return Ok(securityLock);
                }
            }
            return NotFound();
        }
        
        [HttpPost("TakeSecurityLockIdForLaptop")]
        public IActionResult TakeSecurityLockIdForLaptop(int idLaptop,int idSecLock)
        {
            var includSecurityLock = _db.SecurityLocks.SingleOrDefault(p => p.Id == idSecLock);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.SecurityLock.Add(includSecurityLock);      
            _db.SaveChanges();
            return Ok();
        }
        
        // OperatingSystem //
        
        [HttpPost("CreateOperatingSystem")]
        public async Task<IActionResult> CreateOperatingSystem(OperatingSystem operatingSystem)
        {
            _db.OperatingSystems.Add(operatingSystem);
            await _db.SaveChangesAsync();
            return Ok(operatingSystem);
        }
        
        [HttpPut("EditOperatingSystem")]
        public async Task<IActionResult> EditOperatingSystem(OperatingSystem operatingSystem)
        {
            _db.OperatingSystems.Update(operatingSystem);
            await _db.SaveChangesAsync();
            return Ok(operatingSystem);
        }
        
        [HttpDelete("DeleteOperatingSystem")]
        public async Task<IActionResult> DeleteOperatingSystem(int? id)
        {
            if (id != null)
            {
                OperatingSystem operatingSystem = await _db.OperatingSystems.FirstOrDefaultAsync(p => p.Id == id);
                if (operatingSystem != null)
                {
                    _db.OperatingSystems.Remove(operatingSystem);
                    await _db.SaveChangesAsync();
                    return Ok(operatingSystem);
                }
            }
            return NotFound();
        }
        
        [HttpPost("TakeOperatingSystemIdForLaptop")]
        public IActionResult TakeOperatingSystemIdForLaptop(int idLaptop,int idOS)
        {
            var includOS = _db.OperatingSystems.SingleOrDefault(p => p.Id == idOS);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.OperatingSystem.Add(includOS);      
            _db.SaveChanges();
            return Ok();
        }
        
        // Set //
        
        [HttpPost("CreateSet")]
        public async Task<IActionResult> CreateSet(Set set)
        {
            _db.Sets.Add(set);
            await _db.SaveChangesAsync();
            return Ok(set);
        }
        
        [HttpPut("EditSet")]
        public async Task<IActionResult> EditSet(Set set)
        {
            _db.Sets.Update(set);
            await _db.SaveChangesAsync();
            return Ok(set);
        }
        
        [HttpDelete("DeleteSet")]
        public async Task<IActionResult> DeleteSet(int? id)
        {
            if (id != null)
            {
                Set set = await _db.Sets.FirstOrDefaultAsync(p => p.Id == id);
                if (set != null)
                {
                    _db.Sets.Remove(set);
                    await _db.SaveChangesAsync();
                    return Ok(set);
                }
            }
            return NotFound();
        }
        
        [HttpPost("TakeSetIdForLaptop")]
        public IActionResult TakeSetIdForLaptop(int idLaptop,int idSet)
        {
            var includSet = _db.Sets.SingleOrDefault(p => p.Id == idSet);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.Set.Add(includSet);      
            _db.SaveChanges();
            return Ok();
        }
        
        // Keyboard //
        
        [HttpPost("CreateKeyboard")]
        public async Task<IActionResult> CreateKeyboard(Keyboard keyboard)
        {
            _db.Keyboards.Add(keyboard);
            await _db.SaveChangesAsync();
            return Ok(keyboard);
        }
        
        [HttpPut("EditKeyboard")]
        public async Task<IActionResult> EditKeyboard(Keyboard keyboard)
        {
            _db.Keyboards.Update(keyboard);
            await _db.SaveChangesAsync();
            return Ok(keyboard);
        }
        
        [HttpDelete("DeleteKeyboard")]
        public async Task<IActionResult> DeleteKeyboard(int? id)
        {
            if (id != null)
            {
                Keyboard keyboard = await _db.Keyboards.FirstOrDefaultAsync(p => p.Id == id);
                if (keyboard != null)
                {
                    _db.Keyboards.Remove(keyboard);
                    await _db.SaveChangesAsync();
                    return Ok(keyboard);
                }
            }
            return NotFound();
        }
        
        [HttpPost("TakeKeyboardIdForLaptop")]
        public IActionResult TakeKeyboardIdForLaptop(int idLaptop,int idSKeyboard)
        {
            var includKeyboard = _db.Keyboards.SingleOrDefault(p => p.Id == idSKeyboard);
            var includLaptop = _db.Laptops.SingleOrDefault(p => p.Id == idLaptop);
            if (includLaptop != null) includLaptop.Keyboard.Add(includKeyboard);      
            _db.SaveChanges();
            return Ok();
        }
    }
}