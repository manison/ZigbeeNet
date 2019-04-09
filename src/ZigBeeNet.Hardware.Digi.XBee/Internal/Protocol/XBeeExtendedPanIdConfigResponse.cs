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
    ///Class to implement the XBee command " Extended PAN ID Config ".
    /// AT Command <b>ID</b></p>Set or read the 64-bit extended PAN ID. If set to 0, the coordinator
    /// selects a random extended PAN ID, and the router/end device joins any extended PAN ID. 
    ///This class provides methods for processing XBee API commands.
    ///
    ///</summary>
    ///
    public class XBeeExtendedPanIdConfigResponse : XBeeFrame, IXBeeResponse 
    {
        
        /// <summary>
        ///Response field
        ///
        ///</summary>
        ///
        private int _frameId;
        
        /// <summary>
        ///Response field
        ///
        ///</summary>
        ///
        private CommandStatus _commandStatus;
        
        /// <summary>
        ///Response field
        ///
        ///</summary>
        ///
        private ExtendedPanId _extendedPanId;
        
        /// <summary>
        ///Return the frameId as <see cref="System.Int32"/>
        ///
        ///</summary>
        ///
        public int GetFrameId()
        {
            return _frameId;
        }
        
        /// <summary>
        ///Return the commandStatus as <see cref="CommandStatus"/>
        ///
        ///</summary>
        ///
        public CommandStatus GetCommandStatus()
        {
            return _commandStatus;
        }
        
        /// <summary>
        ///Return the extendedPanId as <see cref="ExtendedPanId"/>
        ///
        ///</summary>
        ///
        public ExtendedPanId GetExtendedPanId()
        {
            return _extendedPanId;
        }
        
        /// <summary>
        ///Method for deserializing the fields for the response
        ///</summary>
        ///
        public void Deserialize(int[] incomingData)
        {
            this.InitializeDeserializer(incomingData);
            DeserializeAtCommand();
        }
    }
}
