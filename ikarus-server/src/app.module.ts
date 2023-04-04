import { Module } from '@nestjs/common';
import { AppService } from './app.service';
import { ServerGateway } from './server.gateway';

@Module({
  imports: [],
  controllers: [],
  providers: [AppService, ServerGateway],
})
export class AppModule {}
