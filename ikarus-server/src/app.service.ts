import { Injectable } from '@nestjs/common';
import { Socket } from 'socket.io';

@Injectable()
export class AppService {
  controller: Socket = null;
  game: Socket = null;

  controllerAlreadyConnected() {
    return this.controller != null;
  }
  addController(client: Socket) {
    console.log('Welcome controller :D');
    this.controller = client;
  }

  removeController(client: Socket) {
    this.controller = null;
    console.log('- Bye controller :C');
  }

  isGameConnected() {
    return this.game != null;
  }
  setGame(client: Socket) {
    console.log('Welcome game :D');
    this.game = client;
  }
  isGame(client: Socket) {
    return this.game && this.game.id === client.id;
  }
  removeGame() {
    this.game = null;
    console.log('- Bye game :C');
  }
}
