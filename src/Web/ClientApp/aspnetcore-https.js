// This script sets up HTTPS for the application using the ASP.NET Core HTTPS certificate
const fs = require('fs');
const spawn = require('child_process').spawn;
const path = require('path');

const baseFolder =
  process.env.APPDATA !== undefined && process.env.APPDATA !== ''
    ? `${process.env.APPDATA}/ASP.NET/https`
    : `${process.env.HOME}/.aspnet/dev-certs/https`;

const certificateArg = process.argv.map(arg => arg.match(/--name=(?<value>.+)/i)).filter(Boolean)[0];
const certificateName = certificateArg ? certificateArg.groups.value : process.env.npm_package_name;

if (!certificateName) {
  console.error('Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly.');
  process.exit(-1);
}

const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

// Проверяем, существуют ли файлы сертификата и ключа
if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
  console.log(`Certificate files not found. Trying to create them at: ${certFilePath} and ${keyFilePath}`);

  // Экспортируем сертификат
  const dotnetProcess = spawn('dotnet', [
    'dev-certs',
    'https',
    '--export-path',
    certFilePath,
    '--format',
    'Pem',
    '--no-password',
  ], { stdio: 'inherit' });

  dotnetProcess.on('error', (error) => {
    console.error(`Error spawning dotnet process: ${error.message}`);
  });

  dotnetProcess.on('exit', (code) => {
    console.log(`dotnet dev-certs process exited with code: ${code}`);
    process.exit(code);
  });
} else {
  console.log(`Certificate files already exist at: ${certFilePath} and ${keyFilePath}`);
  process.exit(0);
}
