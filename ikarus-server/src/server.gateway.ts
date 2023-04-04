import {
  MessageBody,
  OnGatewayConnection,
  OnGatewayDisconnect,
  SubscribeMessage,
  WebSocketGateway,
  WebSocketServer,
} from '@nestjs/websockets';
import { Server, Socket } from 'socket.io';
import { AppService } from './app.service';
import { Input } from './DTO/input.dto';

@WebSocketGateway({
  allowEIO3: true,
  cors: {
    origin: '*',
  },
  path: '/server',
})
export class ServerGateway implements OnGatewayConnection, OnGatewayDisconnect {
  @WebSocketServer() server: Server;

  constructor(private appService: AppService) {}

  @SubscribeMessage('input')
  handleInput(@MessageBody() input: Input): void {
    if (!this.appService.isGameConnected()) return;
    this.server.to(this.appService.game.id).emit('input', input);
  }

  handleConnection(client: Socket) {
    const type = client.handshake.query.type;
    switch (type) {
      case 'controller':
        if (this.appService.controllerAlreadyConnected()) {
          client.disconnect(true);
          return;
        }

        this.appService.addController(client);
        break;
      case 'game':
        this.appService.setGame(client);
        break;

      default:
        client.disconnect(true);
        break;
    }
  }
  handleDisconnect(client: Socket) {
    if (this.appService.isGame(client)) {
      this.appService.removeGame();
      return;
    }

    this.appService.removeController(client);
  }
}
