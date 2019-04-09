//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZigBeeNet.Hardware.Digi.XBee.Internal.Protocol
{
    
    
    /// <summary>
    ///Class to implement the XBee command " Get Extended PAN ID Config ".
    /// AT Command <b>ID</b></p>Set or read the 64-bit extended PAN ID. If set to 0, the coordinator
    /// selects a random extended PAN ID, and the router/end device joins any extended PAN ID. 
    ///This class provides methods for processing XBee API commands.
    ///
    ///</summary>
    ///
    public class XBeeGetExtendedPanIdConfigCommand : XBeeFrame, IXBeeCommand 
    {
        
        /// <summary>
        ///
        ///</summary>
        ///
        private int _frameId;
        
        /// <summary>
        ///The frameId to set as
        ///</summary>
        ///
        /// <see cref="uint8"
        ///>
        ///
        ///</see>
        ///
        public void SetFrameId(int frameId)
        {
            this._frameId = frameId;
        }
        
        /// <summary>
        ///Method for serializing the command fields
        ///</summary>
        ///
        public int[] Serialize()
        {
            this.SerializeCommand(8);
            this.SerializeInt8(_frameId);
            this.SerializeAtCommand("ID");
            return this.GetPayload();
        }
    }
}
